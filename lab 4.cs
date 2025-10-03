using System;

// 1. Transport interface
public interface ITransport
{
    void Move();
    void FuelUp();
}

// 2. Concrete transports
public class Car : ITransport
{
    private string Model;
    private int Speed;

    public Car(string model, int speed)
    {
        Model = model;
        Speed = speed;
    }

    public void Move()
    {
        Console.WriteLine($"Car {Model} is driving at {Speed} km/h.");
    }

    public void FuelUp()
    {
        Console.WriteLine($"Car {Model} is being refueled with gasoline.");
    }
}

public class Motorcycle : ITransport
{
    private string Model;
    private int Speed;

    public Motorcycle(string model, int speed)
    {
        Model = model;
        Speed = speed;
    }

    public void Move()
    {
        Console.WriteLine($"Motorcycle {Model} is riding at {Speed} km/h.");
    }

    public void FuelUp()
    {
        Console.WriteLine($"Motorcycle {Model} is being refueled with petrol.");
    }
}

public class Plane : ITransport
{
    private string Model;
    private int Speed;

    public Plane(string model, int speed)
    {
        Model = model;
        Speed = speed;
    }

    public void Move()
    {
        Console.WriteLine($"Plane {Model} is flying at {Speed} km/h.");
    }

    public void FuelUp()
    {
        Console.WriteLine($"Plane {Model} is being refueled with jet fuel.");
    }
}

// Extra type: Bicycle
public class Bicycle : ITransport
{
    private string Model;
    private int Speed;

    public Bicycle(string model, int speed)
    {
        Model = model;
        Speed = speed;
    }

    public void Move()
    {
        Console.WriteLine($"Bicycle {Model} is pedaling at {Speed} km/h.");
    }

    public void FuelUp()
    {
        Console.WriteLine($"Bicycle {Model} doesn’t need fuel – just human energy!");
    }
}

// 3. Abstract Factory
public abstract class TransportFactory
{
    public abstract ITransport CreateTransport(string model, int speed);
}

// 4. Concrete Factories
public class CarFactory : TransportFactory
{
    public override ITransport CreateTransport(string model, int speed)
    {
        return new Car(model, speed);
    }
}

public class MotorcycleFactory : TransportFactory
{
    public override ITransport CreateTransport(string model, int speed)
    {
        return new Motorcycle(model, speed);
    }
}

public class PlaneFactory : TransportFactory
{
    public override ITransport CreateTransport(string model, int speed)
    {
        return new Plane(model, speed);
    }
}

public class BicycleFactory : TransportFactory
{
    public override ITransport CreateTransport(string model, int speed)
    {
        return new Bicycle(model, speed);
    }
}

// 5. Main Program
public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Choose transport type: Car / Motorcycle / Plane / Bicycle");
        string choice = Console.ReadLine();

        Console.WriteLine("Enter model name:");
        string model = Console.ReadLine();

        Console.WriteLine("Enter speed:");
        int speed = int.Parse(Console.ReadLine());

        TransportFactory factory = choice.ToLower() switch
        {
            "car" => new CarFactory(),
            "motorcycle" => new MotorcycleFactory(),
            "plane" => new PlaneFactory(),
            "bicycle" => new BicycleFactory(),
            _ => throw new Exception("Unknown transport type")
        };

        ITransport transport = factory.CreateTransport(model, speed);

        transport.Move();
        transport.FuelUp();
    }
}
