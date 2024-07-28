namespace PrototypeUsingICloneable;

public class ToyPrototype: ICloneable
{
    private readonly string _name, _type;
    private readonly AmountPrototype _price;

    public ToyPrototype(string name, string type, AmountPrototype price)
    {
        _name = name;
        _type = type;
        _price = price;
    }

    public object Clone()
    {
        return new ToyPrototype(_name, _type, (AmountPrototype)_price.Clone());
    }
}

public class AmountPrototype : ICloneable
{
    private readonly int _price;
    private readonly string _currency;

    public AmountPrototype(int price, string currency)
    {
        _price = price;
        _currency = currency;
    }

    public object Clone()
    {
        return new AmountPrototype(_price, _currency);
    }
}
