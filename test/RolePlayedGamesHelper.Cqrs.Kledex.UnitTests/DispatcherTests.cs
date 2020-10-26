using System.Threading.Tasks;
using AutoFixture;
using Moq;
using RolePlayedGamesHelper.Cqrs.Kledex.Bus;
using RolePlayedGamesHelper.Cqrs.Kledex.Commands;
using RolePlayedGamesHelper.Cqrs.Kledex.Events;
using RolePlayedGamesHelper.Cqrs.Kledex.Queries;
using RolePlayedGamesHelper.Cqrs.Kledex.UnitTests.Fakes;
using Xunit;

namespace RolePlayedGamesHelper.Cqrs.Kledex.UnitTests
{
  public class DispatcherTests
  {
    private IDispatcher sut;

    private Mock<ICommandSender> commandSender;
    private Mock<IEventPublisher> eventPublisher;
    private Mock<IBusMessageDispatcher> busMessageDispatcher;
    private Mock<IQueryProcessor> queryProcessor;

    private SomethingCreated somethingCreated;
    private Something something;
    private CreateAggregate createAggregate;
    private CreateAggregateBusMessage createAggregateBusMessage;
    private SampleCommandSequence sampleCommandSequence;

    public DispatcherTests()
    {
      somethingCreated = new SomethingCreated();
      something = new Something();
      createAggregate = new CreateAggregate();
      createAggregateBusMessage = new CreateAggregateBusMessage();
      sampleCommandSequence = new SampleCommandSequence();

      commandSender = new Mock<ICommandSender>();
      commandSender
          .Setup(x => x.SendAsync(createAggregate))
          .Returns(Task.CompletedTask);
      commandSender
          .Setup(x => x.Send(createAggregate));
      commandSender
          .Setup(x => x.SendAsync(sampleCommandSequence))
          .Returns(Task.CompletedTask);
      commandSender
          .Setup(x => x.Send(sampleCommandSequence));

      eventPublisher = new Mock<IEventPublisher>();
      eventPublisher
          .Setup(x => x.PublishAsync(somethingCreated))
          .Returns(Task.CompletedTask);
      eventPublisher
          .Setup(x => x.Publish(somethingCreated));

      busMessageDispatcher = new Mock<IBusMessageDispatcher>();
      busMessageDispatcher
          .Setup(x => x.DispatchAsync(createAggregateBusMessage))
          .Returns(Task.CompletedTask);

      queryProcessor = new Mock<IQueryProcessor>();

      sut = new Dispatcher(
              commandSender.Object,
                eventPublisher.Object,
              queryProcessor.Object,
                busMessageDispatcher.Object);
    }

    [Fact]
    public async Task SendsCommandAsync()
    {
      await sut.SendAsync(createAggregate);
      commandSender.Verify(x => x.SendAsync(createAggregate), Times.Once);
    }

    [Fact]
    public async Task SendsCommandWithResultAsync()
    {
      await sut.SendAsync<string>(createAggregate);
      commandSender.Verify(x => x.SendAsync<string>(createAggregate), Times.Once);
    }

    [Fact]
    public async Task SendsCommandSequenceAsync()
    {
      await sut.SendAsync(sampleCommandSequence);
      commandSender.Verify(x => x.SendAsync(sampleCommandSequence), Times.Once);
    }

    [Fact]
    public async Task SendsCommandSequenceWithResultAsync()
    {
      await sut.SendAsync<string>(sampleCommandSequence);
      commandSender.Verify(x => x.SendAsync<string>(sampleCommandSequence), Times.Once);
    }

    [Fact]
    public void SendsCommand()
    {
      sut.Send(createAggregate);
      commandSender.Verify(x => x.Send(createAggregate), Times.Once);
    }

    [Fact]
    public void SendsCommandWithResult()
    {
      sut.Send<string>(createAggregate);
      commandSender.Verify(x => x.Send<string>(createAggregate), Times.Once);
    }

    [Fact]
    public void SendsCommandSequence()
    {
      sut.Send(sampleCommandSequence);
      commandSender.Verify(x => x.Send(sampleCommandSequence), Times.Once);
    }

    [Fact]
    public void SendsCommandSequenceWithResult()
    {
      sut.Send<string>(sampleCommandSequence);
      commandSender.Verify(x => x.Send<string>(sampleCommandSequence), Times.Once);
    }

    [Fact]
    public async Task PublishesEventAsync()
    {
      await sut.PublishAsync(somethingCreated);
      eventPublisher.Verify(x => x.PublishAsync(somethingCreated), Times.Once);
    }

    [Fact]
    public void PublishesEvent()
    {
      sut.Publish(somethingCreated);
      eventPublisher.Verify(x => x.Publish(somethingCreated), Times.Once);
    }

    [Fact]
    public async Task DispatchesBusMessageAsync()
    {
      await sut.DispatchBusMessageAsync(createAggregateBusMessage);
      busMessageDispatcher.Verify(x => x.DispatchAsync(createAggregateBusMessage), Times.Once);
    }
  }
}
