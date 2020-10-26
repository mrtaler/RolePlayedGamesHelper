//using System;
//using System.Collections.Generic;
//using System.Linq;
//using FluentAssertions;
//using Microsoft.Extensions.Options;
//using Moq;
//using RolePlayedGamesHelper.Cqrs.Kledex.Commands;
//using RolePlayedGamesHelper.Cqrs.Kledex.Configuration;
//using RolePlayedGamesHelper.Cqrs.Kledex.Dependencies;
//using RolePlayedGamesHelper.Cqrs.Kledex.Domain;
//using RolePlayedGamesHelper.Cqrs.Kledex.Events;
//using RolePlayedGamesHelper.Cqrs.Kledex.Mapping;
//using RolePlayedGamesHelper.Cqrs.Kledex.UnitTests.Fakes;
//using RolePlayedGamesHelper.Cqrs.Kledex.Validation;
//using Xunit;
//using Options = RolePlayedGamesHelper.Cqrs.Kledex.Configuration.Options;

//namespace RolePlayedGamesHelper.Cqrs.Kledex.UnitTests.Commands
//{
//  public class CommandSenderSyncTests
//  {
//    private ICommandSender sut;

//    private Mock<IHandlerResolver> handlerResolver;
//    private Mock<IEventPublisher> eventPublisher;
//    private Mock<IStoreProvider> storeProvider;
//    private Mock<IEventFactory> objectFactory;
//    private Mock<IValidationService> validationService;

//    private Mock<ICommandHandler<CreateSomething>> commandHandler;
//    private Mock<ICommandHandler<CreateAggregate>> domainCommandHandler;
//    private Mock<ISequenceCommandHandler<CommandInSequence>> sequenceCommandHandler;
//    private Mock<IOptions<Configuration.Options>> mainOptionsMock;

//    private CreateSomething createSomething;
//    private CreateSomething createSomethingConcrete;
//    private SomethingCreated somethingCreated;
//    private SomethingCreated somethingCreatedConcrete;
//    private IEnumerable<IEvent> events;

//    private CreateAggregate createAggregate;
//    private CreateAggregate createAggregateConcrete;
//    private AggregateCreated aggregateCreated;
//    private AggregateCreated aggregateCreatedConcrete;
//    private Aggregate aggregate;

//    private SampleCommandSequence sampleCommandSequence;
//    private CommandInSequence commandInSequenceConcrete;

//    private CommandResponse commandResponse;
//    private CommandResponse domainCommandResponse;

//    private SaveStoreData storeDataSaved;

//    public CommandSenderSyncTests()
//    {
//      createSomething = new CreateSomething();
//      createSomethingConcrete = new CreateSomething();
//      somethingCreated = new SomethingCreated();
//      somethingCreatedConcrete = new SomethingCreated();
//      events = new List<IEvent> { somethingCreated };

//      createAggregate = new CreateAggregate();
//      createAggregateConcrete = new CreateAggregate();
//      aggregateCreatedConcrete = new AggregateCreated();
//      aggregate = new Aggregate();
//      aggregateCreated = (AggregateCreated)aggregate.Events[0];

//      sampleCommandSequence = new SampleCommandSequence();
//      commandInSequenceConcrete = new CommandInSequence();

//      commandResponse = new CommandResponse { Events = events, Result = "Result" };
//      domainCommandResponse = new CommandResponse { Events = aggregate.Events, Result = "Result" };

//      eventPublisher = new Mock<IEventPublisher>();
//      eventPublisher
//          .Setup(x => x.Publish(aggregateCreatedConcrete));

//      storeProvider = new Mock<IStoreProvider>();
//      storeProvider
//          .Setup(x => x.Save(It.IsAny<SaveStoreData>()))
//          .Callback<SaveStoreData>(x => storeDataSaved = x);

//      objectFactory = new Mock<IEventFactory>();
//      objectFactory
//          .Setup(x => x.CreateConcreteEvent(somethingCreated))
//          .Returns(somethingCreatedConcrete);
//      objectFactory
//          .Setup(x => x.CreateConcreteEvent(aggregateCreated))
//          .Returns(aggregateCreatedConcrete);
//      objectFactory
//          .Setup(x => x.CreateConcreteEvent(createSomething))
//          .Returns(createSomethingConcrete);
//      objectFactory
//          .Setup(x => x.CreateConcreteEvent(createAggregate))
//          .Returns(createAggregateConcrete);
//      objectFactory
//          .Setup(x => x.CreateConcreteEvent(It.IsAny<CommandInSequence>()))
//          .Returns(commandInSequenceConcrete);

//      validationService = new Mock<IValidationService>();
//      validationService
//          .Setup(x => x.Validate(It.IsAny<CreateSomething>()));

//      commandHandler = new Mock<ICommandHandler<CreateSomething>>();
//      commandHandler
//          .Setup(x => x.Handle(createSomethingConcrete))
//          .Returns(commandResponse);

//      domainCommandHandler = new Mock<ICommandHandler<CreateAggregate>>();
//      domainCommandHandler
//          .Setup(x => x.Handle(createAggregate))
//          .Returns(domainCommandResponse);
//      domainCommandHandler
//          .Setup(x => x.Handle(createAggregateConcrete))
//          .Returns(domainCommandResponse);

//      sequenceCommandHandler = new Mock<ISequenceCommandHandler<CommandInSequence>>();
//      sequenceCommandHandler
//          .Setup(x => x.Handle(It.IsAny<CommandInSequence>(), It.IsAny<CommandResponse>()))
//          .Returns(commandResponse);

//      handlerResolver = new Mock<IHandlerResolver>();
//      handlerResolver
//          .Setup(x => x.ResolveHandler<ICommandHandler<CreateSomething>>())
//          .Returns(commandHandler.Object);

//      handlerResolver
//        .Setup(x => x.ResolveHandler(It.IsAny<CreateSomething>(),It.IsAny<Type>()))
//        .Returns(commandHandler.Object);

//      handlerResolver
//          .Setup(x => x.ResolveHandler<ICommandHandler<CreateAggregate>>())
//          .Returns(domainCommandHandler.Object);
//      handlerResolver
//          .Setup(x => x.ResolveHandler<ISequenceCommandHandler<CommandInSequence>>())
//          .Returns(sequenceCommandHandler.Object);

//      mainOptionsMock = new Mock<IOptions<Configuration.Options>>();
//      mainOptionsMock
//          .Setup(x => x.Value)
//          .Returns(new Configuration.Options());

//      sut = new CommandSender(
//        handlerResolver.Object,
//          eventPublisher.Object,
//          objectFactory.Object,
//          storeProvider.Object,
//          validationService.Object,
//          mainOptionsMock.Object);
//    }

//    [Fact]
//    public void Send_ThrowsException_WhenCommandIsNull()
//    {
//      createAggregate = null;
//      Assert.Throws<ArgumentNullException>(() => sut.Send(createAggregate));
//    }

//    [Fact]
//    public void Send_ValidatesCommand()
//    {
//      createSomething.Validate = true;
//      sut.Send(createSomething);
//      validationService.Verify(x => x.Validate(It.IsAny<CreateSomething>()), Times.Once);
//    }

//    [Fact]
//    public void Send_HandlesCommand()
//    {
//      sut.Send(createSomething);
//      commandHandler.Verify(x => x.Handle(createSomething), Times.Once);
//    }

//    [Fact]
//    public void Send_HandlesDomainCommand()
//    {
//      sut.Send(createAggregate);
//      domainCommandHandler.Verify(x => x.Handle(createAggregate), Times.Once);
//    }

//    [Fact]
//    public void Send_HandlesCommand_InCommandSequence()
//    {
//      sut.Send(sampleCommandSequence);
//      sequenceCommandHandler.Verify(x => x.Handle(It.IsAny<CommandInSequence>(), It.IsAny<CommandResponse>()), Times.Once);
//    }

//    [Fact]
//    public void Send_SavesStoreData()
//    {
//      sut.Send(createAggregate);
//      storeProvider.Verify(x => x.Save(It.IsAny<SaveStoreData>()), Times.Once);
//    }

//    [Fact]
//    public void Send_SavesCorrectData()
//    {
//      sut.Send(createAggregate);

//      storeDataSaved.AggregateType.Should().BeOfType(aggregate.GetType());
//      storeDataSaved.AggregateRootId.Should().Be(createAggregate.AggregateRootId);
//      storeDataSaved.Events.FirstOrDefault().Should().Be(aggregateCreated);
//      storeDataSaved.DomainCommand.Should().Be(createAggregate);

//      /*
//      Assert.AreEqual(aggregate.GetType(), storeDataSaved.AggregateType);
//      Assert.AreEqual(createAggregate.AggregateRootId, storeDataSaved.AggregateRootId);
//      Assert.AreEqual(aggregateCreated, storeDataSaved.Events.FirstOrDefault());
//      Assert.AreEqual(createAggregate, storeDataSaved.DomainCommand);
//      */
//    }

//    [Fact]
//    public void Send_PublishesEvents()
//    {
//      sut.Send(createAggregate);
//      eventPublisher.Verify(x => x.Publish(aggregateCreatedConcrete), Times.Once);
//    }

//    [Fact]
//    public void Send_NotPublishesEvents_WhenSetInOptions()
//    {
//      mainOptionsMock
//          .Setup(x => x.Value)
//          .Returns(new Options { PublishEvents = false });

//      sut = new CommandSender(handlerResolver.Object,
//          eventPublisher.Object,
//          objectFactory.Object,
//          storeProvider.Object,
//          new Mock<IValidationService>().Object,
//          mainOptionsMock.Object);

//      sut.Send(createAggregate);
//      eventPublisher.Verify(x => x.Publish(aggregateCreatedConcrete), Times.Never);
//    }

//    [Fact]
//    public void Send_NotPublishesEvents_WhenSetInCommand()
//    {
//      createAggregate.PublishEvents = false;
//      sut.Send(createAggregate);
//      eventPublisher.Verify(x => x.Publish(aggregateCreatedConcrete), Times.Never);
//    }

//    [Fact]
//    public void SendWithResult_ReturnsResult()
//    {
//      var actual = sut.Send<string>(createSomething);
//      actual.Should().Be("Result");

//      // Assert.AreEqual("Result", actual);
//    }
//  }
//}
