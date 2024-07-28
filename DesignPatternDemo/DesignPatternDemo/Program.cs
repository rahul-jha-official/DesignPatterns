
using StepwiseBuilder;
using FluentBuilderWithRecursiveGenerics;
using SOLIDPrinciple.OpenClosePrinciple;
using FunctionalBuilder;
using FacetedBuilder;
using Singleton;
using Monostate;
using PerThreadSingleton;
using Bridge;
using Factory;
using ObjectFactory;
using ObjectTrackingAndBulkReplacement;
using CopyUsingExtension;
using PrototypeUsingICloneable;
using CopyUsingConstructor;
using CopyUsingCustomInterface;
using VectorRasterAdapter;
using Adapter;

//TestOCP();
//TestFluentBuilderWithRecursiveGenerics();
//TestStepwiseBuilder();
//TestFunctionalBuilder();
//TestFacetedBuilder();
//TestSingleton();
//TestMonostate();
//TestPerThreadSingleton();
//TestBridge();
//TestFactory();
//TestObjectFactory();
//TestObjectTrackingAndBulkReplacement();
//TestPrototype();
//TestAdapter();
TestCachedAdapter();

Console.ReadKey();

void TestOCP()
{
    //Test SOLID: Open Close Principle
    //Filter Product of White color and Medium Size
    ISpecification<Product> white = new Specifications(new ColorSpecification(Color.White), new SizeSpecification(Size.M));
    IFilter<Product> filter = new ProductFilter();
    var res = filter.Filter(ProductsSampleData.Products, white);
    Console.WriteLine(string.Join(Environment.NewLine, res));
}

void TestFluentBuilderWithRecursiveGenerics()
{
    var person = Person.Create
                        .Named("Priyansh")
                        .WorksAsA(Position.Developer)
                        .BornOn(new DateOnly(1996, 8, 10))
                        .Build();
    Console.WriteLine(person);
}

void TestStepwiseBuilder()
{
    Car car = CarBuilder
                .NewCar
                .OfCarType(CarType.Sedan)
                .WithWheelSize(18)
                .Build();

    Console.WriteLine(car);
}

void TestFunctionalBuilder()
{
    var eBuilder = new EmployeeBuilder();
    var emp = eBuilder.WorkAs(Designation.Staff).Called("Nakun Lamba").Build();
    Console.WriteLine(emp); 
}

void TestFacetedBuilder()
{
    Student student = new StudentBuilder()
                        .Profile
                            .Called("Harry Potter")
                            .ParentsAre("James Potter", "Lily Potter")
                            .BornOn(31, 7, 1980)
                        .Lives
                            .At("12 Picket Post Close")
                            .WithPostcode("12345")
                            .In("Bracknell")
                        .Study
                            .InCollege("Hogwards")
                            .Persuing(Degree.Witchcarft)
                            .CurrentYear(Year.FirstYear);

    Console.WriteLine(student);
}

void TestSingleton()
{
    var db = SingletonDatabase.Instance();
    Console.WriteLine(db.GetPopulation("Jhansi"));
}

void TestMonostate()
{
    var ceo = new CEO();
    ceo.Name = "John Wick";
    ceo.Age = 52;

    var ceo2 = new CEO();
    Console.WriteLine(ceo2);
}

void TestPerThreadSingleton()
{
    var t1 = Task.Factory.StartNew(() =>
    {
        var x1 = ThreaderObject.Instance;
        var x2 = ThreaderObject.Instance;

        Console.WriteLine(x1.Id);
        Console.WriteLine(x2.Id);
    });

    var t2 = Task.Factory.StartNew(() =>
    {
        var x1 = ThreaderObject.Instance;
        var x2 = ThreaderObject.Instance;

        Console.WriteLine(x1.Id);
        Console.WriteLine(x2.Id);
    });

    Task.WaitAll(t1,t2);
}

void TestBridge()
{
    IImageRenderer legacy = new LegacyImageRenderer();
    IImageRenderer advance = new AdvanceImageRenderer();

    var renderer = new RenderImage(legacy);
    renderer.Render(new Image());
    renderer = new RenderImage(advance);
    renderer.Render(new Image());
}

void TestFactory()
{
    var cart = Point.CartesianPoint(1, 2);
    var polar = Point.PolarPoint(Math.PI / 2, Math.PI / 2);

    Console.WriteLine(cart);
    Console.WriteLine(polar);
}

void TestObjectFactory()
{
    var themes = new HashSet<ITheme>
    {
        new LightTheme(),
        new DarkTheme(),
        new SystemTheme(),
    };

    var theme = new ThemeFactory(themes).GetTheme(Theme.Light);
    theme.Apply();
}

void TestObjectTrackingAndBulkReplacement()
{
    var f1 = new LookAndFeelTrackingFactory();
    var uis = new ILookAndFeel[]
    {
        f1.GetUI(false),
        f1.GetUI(true),
        f1.GetUI(true),
        f1.GetUI(false),
        f1.GetUI(false)
    };

    Console.WriteLine(f1.Info);
    Console.WriteLine("---------");

    var f2 = new LookAndFeelBulkReplacementFactory();
    var replacableUIs = new Ref<ILookAndFeel>[]
    {
        f2.GetUI(false),
        f2.GetUI(true),
        f2.GetUI(true),
        f2.GetUI(false),
        f2.GetUI(false)
    };

    Console.WriteLine("Initials::");
    Console.WriteLine(f2.Info);

    f2.ReplaceAll(true);
    Console.WriteLine("Changed All to dark::");
    Console.WriteLine(f2.Info);
    f2.ReplaceAll(false);
    Console.WriteLine("Changed All to light::");
    Console.WriteLine(f2.Info);
}

void TestPrototype()
{
    var toy = new ToyPrototype("Robot", "Plastic", new AmountPrototype(30, "INR"));
    var toyCopy = (ToyPrototype) toy.Clone();

    var laptop = new LaptopPrototype("Acer Predator Helios 300", "i9 12th Generation", new DiskPrototype("Samsung", 1));
    var laptopCopy = new LaptopPrototype(laptop);

    var mobile = new MobilePrototype("Google", "Pixel 4a", new DisplayPrototype(DisplayType.OLED, 6, 7));
    var mobileCopy = mobile.DeepCopy();

    var table = new TablePrototype("Sinmex", new MaterialPrototype(WoodType.Oak, 7, 5));
    var tableCopy = table.DeepCopyExtension();
    tableCopy.Brand = "JMx";
}

void TestAdapter()
{
    var rectangle = new VectorRectangle(1, 1, 10, 10);
    var adapter = new LineToPointAdapter();
    var drawer = new DrawPixel();
    foreach (var line in rectangle)
    {
        var crs = adapter.GenerateCoordinates(line);

        foreach (var coordinate in crs)
        {
            drawer.Draw(coordinate);
        }
    }
}

void TestCachedAdapter()
{
    var rectangle = new VectorRectangle(1, 1, 10, 10);
    var adapter = new LineToPointCachedAdapter(new LineToPointAdapter());
    var drawer = new DrawPixel();
    foreach (var line in rectangle)
    {
        var c1 = adapter.GenerateCoordinates(line);
        var c2 = adapter.GenerateCoordinates(line);

        foreach (var coordinate in c1)
        {
            drawer.Draw(coordinate);
        }
    }
}