using Newtonsoft.Json;

namespace StepwiseBuilder;

public enum CarType
{
    Sedan,
    Crossover
}

public class Car
{
    public CarType CarType;
    public int WheelSize;

    public override string ToString()
    {
        return JsonConvert.SerializeObject(this);
    }
}

public interface ISpecifyCarType
{
    ISpecifyWheelSize OfCarType(CarType type);
}

public interface ISpecifyWheelSize
{
    IBuildCar WithWheelSize(int wheelSize);
}

public interface IBuildCar
{
    Car Build();
}

public class CarBuilder
{
    public static ISpecifyCarType NewCar => new CreateCar();

    private class CreateCar : ISpecifyCarType, ISpecifyWheelSize, IBuildCar
    {
        private Car _car;
        public CreateCar()
        {
            _car = new Car();
        }
        public ISpecifyWheelSize OfCarType(CarType type)
        {
            _car.CarType = type;
            return this;
        }
        public IBuildCar WithWheelSize(int wheelSize)
        {
            switch (_car.CarType)
            {
                case CarType.Sedan when wheelSize < 17 || wheelSize > 20:
                case CarType.Crossover when wheelSize < 15 || wheelSize > 17:
                    throw new ArgumentException($"Wrong wheel size for {_car.CarType} Type");

            }
            _car.WheelSize = wheelSize;
            return this;
        }
        public Car Build()
        {
            return _car;
        }
    }
}