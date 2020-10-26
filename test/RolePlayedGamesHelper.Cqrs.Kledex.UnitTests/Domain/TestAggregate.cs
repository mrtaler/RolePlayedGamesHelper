using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using RolePlayedGamesHelper.Cqrs.Kledex.Domain;

namespace RolePlayedGamesHelper.Cqrs.Kledex.UnitTests.Domain
{
  public class TestAggregate : AggregateRoot
  {
    public Int32 Number { get; private set; }
    private readonly List<Item> _lineItems = new List<Item>();
    public ReadOnlyCollection<Item> Items => _lineItems.AsReadOnly();

    public TestAggregate()
    {
    }

    public TestAggregate(Int32 number)
    {
      AddAndApplyEvent(new TestAggregateCreated(number));
    }

    private void Apply(TestAggregateCreated @event)
    {
      Number = @event.Number;
    }

    public void AddItem(String v1, Int32 v2, Double v3, Boolean v4)
    {
      AddAndApplyEvent(new ItemAdded()
      {
        AggregateRootId = Id,
        Description     = v1,
        Quantity        = v2,
        Price           = v3,
        Taxable         = v4
      });
    }

    private void Apply(ItemAdded @event)
    {
      _lineItems.Add(new Item(Version, @event.Description, @event.Quantity, @event.Price, @event.Taxable));
    }

    public void RemoveItem(Int32 id)
    {
      AddAndApplyEvent(new ItemRemoved()
      {
        AggregateRootId = Id,
        ItemId          = id
      });
    }

    private void Apply(ItemRemoved @event)
    {
      var item = _lineItems.SingleOrDefault(l => l.Id == @event.ItemId);
      if (item != null)
      {
        _lineItems.Remove(item);
      }
    }

    public void ChangeItem(Int32 id, String description)
    {
      AddAndApplyEvent(new ItemDescriptionChanged()
      {
        AggregateRootId = Id,
        ItemId          = id,
        Description     = description
      });
    }

    private void Apply(ItemDescriptionChanged @event)
    {
      var item = _lineItems.SingleOrDefault(l => l.Id == @event.ItemId);
      if (item != null)
      {
        _lineItems.Remove(item);
      }
      _lineItems.Add(new Item(item.Id, @event.Description, item.Quantity, item.Price, item.Taxable));
    }

    public void ChangeItem(Int32 id, Int32 quantity)
    {
      AddAndApplyEvent(new ItemQuantityChanged()
      {
        AggregateRootId = Id,
        ItemId          = id,
        Quantity        = quantity
      });
    }

    private void Apply(ItemQuantityChanged @event)
    {
      var item = _lineItems.SingleOrDefault(l => l.Id == @event.ItemId);
      if (item != null)
      {
        _lineItems.Remove(item);
      }
      _lineItems.Add(new Item(item.Id, item.Description, @event.Quantity, item.Price, item.Taxable));
    }

  }
}