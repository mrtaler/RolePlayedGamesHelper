using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.Extensions.Options;
using Moq;
using RolePlayedGamesHelper.Cqrs.Kledex.Commands;
using RolePlayedGamesHelper.Cqrs.Kledex.Configuration;
using RolePlayedGamesHelper.Cqrs.Kledex.Dependencies;
using RolePlayedGamesHelper.Cqrs.Kledex.Domain;
using RolePlayedGamesHelper.Cqrs.Kledex.Events;
using RolePlayedGamesHelper.Cqrs.Kledex.Mapping;
using RolePlayedGamesHelper.Cqrs.Kledex.UnitTests.Fakes;
using RolePlayedGamesHelper.Cqrs.Kledex.Validation;
using Xunit;

namespace RolePlayedGamesHelper.Cqrs.Kledex.UnitTests.Commands
{
  public class CommandSenderAsyncTests
  {
    private ICommandSender sut;

    private Mock<IHandlerResolver> handlerResolver;
    private Mock<IEventPublisher> eventPublisher;
    private Mock<IStoreProvider> storeProvider;
    private Mock<IEventFactory> objectFactory;
    private Mock<IValidationService> validationService;

    private Mock<ICommandHandlerAsync<CreateSomething>> commandHandlerAsync;
    private Mock<ICommandHandlerAsync<CreateAggregate>> domainCommandHandlerAsync;
    private Mock<ISequenceCommandHandlerAsync<CommandInSequence>> sequenceCommandHandlerAsync;
    private Mock<IOptions<RolePlayedGamesHelper.Cqrs.Kledex.Configuration.Options>> mainOptionsMock;

    private CreateSomething createSomething;
    private CreateSomething createSomethingConcrete;
    private SomethingCreated somethingCreated;
    private SomethingCreated somethingCreatedConcrete;
    private IEnumerable<IEvent> events;

    private CreateAggregate createAggregate;
    private CreateAggregate createAggregateConcrete;
    private AggregateCreated aggregateCreated;
    private AggregateCreated aggregateCreatedConcrete;
    private Aggregate aggregate;

    private SampleCommandSequence sampleCommandSequence;
    private CommandInSequence commandInSequenceConcrete;

    private CommandResponse commandResponse;
    private CommandResponse domainCommandResponse;

    private SaveStoreData storeDataSaved;


    public CommandSenderAsyncTests()
    {
      createSomething = new CreateSomething();
      createSomethingConcrete = new CreateSomething();
      somethingCreated = new SomethingCreated();
      somethingCreatedConcrete = new SomethingCreated();
      events = new List<IEvent> { somethingCreated };

      createAggregate = new CreateAggregate();
      createAggregateConcrete = new CreateAggregate();
      aggregateCreatedConcrete = new AggregateCreated();
      aggregate = new Aggregate();
      aggregateCreated = (AggregateCreated)aggregate.Events[0];

      sampleCommandSequence = new SampleCommandSequence();
      commandInSequenceConcrete = new CommandInSequence();

      commandResponse = new CommandResponse { Events = events, Result = "Result" };
      domainCommandResponse = new CommandResponse { Events = aggregate.Events, Result = "Result" };

      eventPublisher = new Mock<IEventPublisher>();
      eventPublisher
          .Setup(x => x.PublishAsync(aggregateCreatedConcrete))
          .Returns(Task.CompletedTask);

      storeProvider = new Mock<IStoreProvider>();
      storeProvider
          .Setup(x => x.SaveAsync(It.IsAny<SaveStoreData>()))
          .Callback<SaveStoreData>(x => storeDataSaved = x)
          .Returns(Task.CompletedTask);

      objectFactory = new Mock<IEventFactory>();
      objectFactory
          .Setup(x => x.CreateConcreteEvent(somethingCreated))
          .Returns(somethingCreatedConcrete);
      objectFactory
          .Setup(x => x.CreateConcreteEvent(aggregateCreated))
          .Returns(aggregateCreatedConcrete);
      objectFactory
          .Setup(x => x.CreateConcreteEvent(createSomething))
          .Returns(createSomethingConcrete);
      objectFactory
          .Setup(x => x.CreateConcreteEvent(createAggregate))
          .Returns(createAggregateConcrete);
      objectFactory
          .Setup(x => x.CreateConcreteEvent(It.IsAny<CommandInSequence>()))
          .Returns(commandInSequenceConcrete);

      validationService = new Mock<IValidationService>();
      validationService
          .Setup(x => x.ValidateAsync(It.IsAny<CreateSomething>()))
          .Returns(Task.CompletedTask);

      commandHandlerAsync = new Mock<ICommandHandlerAsync<CreateSomething>>();
      commandHandlerAsync
          .Setup(x => x.HandleAsync(createSomethingConcrete))
          .ReturnsAsync(commandResponse);

      domainCommandHandlerAsync = new Mock<ICommandHandlerAsync<CreateAggregate>>();
      domainCommandHandlerAsync
          .Setup(x => x.HandleAsync(createAggregate))
          .ReturnsAsync(domainCommandResponse);
      domainCommandHandlerAsync
          .Setup(x => x.HandleAsync(createAggregateConcrete))
          .ReturnsAsync(domainCommandResponse);

      sequenceCommandHandlerAsync = new Mock<ISequenceCommandHandlerAsync<CommandInSequence>>();
      sequenceCommandHandlerAsync
          .Setup(x => x.HandleAsync(It.IsAny<CommandInSequence>(), It.IsAny<CommandResponse>()))
          .ReturnsAsync(commandResponse);

      handlerResolver = new Mock<IHandlerResolver>();
      handlerResolver
          .Setup(x => x.ResolveHandler<ICommandHandlerAsync<CreateSomething>>())
          .Returns(commandHandlerAsync.Object);
      handlerResolver
          .Setup(x => x.ResolveHandler<ICommandHandlerAsync<CreateAggregate>>())
          .Returns(domainCommandHandlerAsync.Object);
      handlerResolver
          .Setup(x => x.ResolveHandler<ISequenceCommandHandlerAsync<CommandInSequence>>())
          .Returns(sequenceCommandHandlerAsync.Object);

      mainOptionsMock = new Mock<IOptions<RolePlayedGamesHelper.Cqrs.Kledex.Configuration.Options>>();
      mainOptionsMock
          .Setup(x => x.Value)
          .Returns(new Configuration.Options());

      sut = new CommandSender(handlerResolver.Object,
          eventPublisher.Object,
          objectFactory.Object,
          storeProvider.Object,
          validationService.Object,
          mainOptionsMock.Object);
    }

    [Fact]
    public void SendAsync_ThrowsException_WhenCommandIsNull()
    {
      createAggregate = null;
      Assert.ThrowsAsync<ArgumentNullException>(async () => await sut.SendAsync(createAggregate));
    }

    [Fact]
    public async Task SendAsync_ValidatesCommand()
    {
      createSomething.Validate = true;
      await sut.SendAsync(createSomething);
      validationService.Verify(x => x.ValidateAsync(It.IsAny<CreateSomething>()), Times.Once);
    }

    [Fact]
    public async Task SendAsync_HandlesCommand()
    {
      await sut.SendAsync(createSomething);
      commandHandlerAsync.Verify(x => x.HandleAsync(createSomething), Times.Once);
    }

    [Fact]
    public async Task SendAsync_HandlesDomainCommand()
    {
      await sut.SendAsync(createAggregate);
      domainCommandHandlerAsync.Verify(x => x.HandleAsync(createAggregate), Times.Once);
    }

    [Fact]
    public async Task SendAsync_HandlesCommand_InCommandSequence()
    {
      await sut.SendAsync(sampleCommandSequence);
      sequenceCommandHandlerAsync.Verify(x => x.HandleAsync(It.IsAny<CommandInSequence>(), It.IsAny<CommandResponse>()), Times.Once);
    }

    [Fact]
    public async Task SendAsync_SavesStoreData()
    {
      await sut.SendAsync(createAggregate);
      storeProvider.Verify(x => x.SaveAsync(It.IsAny<SaveStoreData>()), Times.Once);
    }

    [Fact]
    public async Task SendAsync_SavesCorrectData()
    {
      await sut.SendAsync(createAggregate);
      storeDataSaved.AggregateType.Should().BeOfType(aggregate.GetType());
      storeDataSaved.AggregateRootId.Should().Be(createAggregate.AggregateRootId);
      storeDataSaved.Events.FirstOrDefault().Should().Be(aggregateCreated);
      storeDataSaved.DomainCommand.Should().Be(createAggregate);
      /*
      Assert.AreEqual(_aggregate.GetType(), _storeDataSaved.AggregateType);
      Assert.AreEqual(_createAggregate.AggregateRootId, _storeDataSaved.AggregateRootId);
      Assert.AreEqual(_aggregateCreated, _storeDataSaved.Events.FirstOrDefault());
      Assert.AreEqual(_createAggregate, _storeDataSaved.DomainCommand);
      */
    }

    [Fact]
    public async Task SendAsync_PublishesEvents()
    {
      await sut.SendAsync(createAggregate);
      eventPublisher.Verify(x => x.PublishAsync(aggregateCreatedConcrete), Times.Once);
    }

    [Fact]
    public async Task SendAsync_NotPublishesEvents_WhenSetInOptions()
    {
      mainOptionsMock
          .Setup(x => x.Value)
          .Returns(new RolePlayedGamesHelper.Cqrs.Kledex.Configuration.Options { PublishEvents = false });

      sut = new CommandSender(handlerResolver.Object,
          eventPublisher.Object,
          objectFactory.Object,
          storeProvider.Object,
          new Mock<IValidationService>().Object,
          mainOptionsMock.Object);

      await sut.SendAsync(createAggregate);
      eventPublisher.Verify(x => x.PublishAsync(aggregateCreatedConcrete), Times.Never);
    }

    [Fact]
    public async Task SendAsync_NotPublishesEvents_WhenSetInCommand()
    {
      createAggregate.PublishEvents = false;
      await sut.SendAsync(createAggregate);
      eventPublisher.Verify(x => x.PublishAsync(aggregateCreatedConcrete), Times.Never);
    }

    [Fact]
    public async Task SendAsyncWithResult_ReturnsResult()
    {
      var actual = await sut.SendAsync<string>(createSomething);
      actual.Should().Be("Result");

      // Assert.AreEqual("Result", actual);
    }
  }
}
