using System;

namespace RolePlayedGamesHelper.Cqrs.Kledex.UnitTests.Domain
{
  public class Item
  {
    public Item(Int32 id, String description, Int32 quantity, Double price, Boolean taxable)
    {
      Id          = id;
      Description = description ?? throw new ArgumentNullException(nameof(description));
      Quantity    = quantity;
      Price       = price;
      Taxable     = taxable;
    }

    public Int32 Id { get; }
    public String Description { get; }
    public Int32 Quantity { get; }
    public Double Price { get; }
    public Boolean Taxable { get; }
  }
}