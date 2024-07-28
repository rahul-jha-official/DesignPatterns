using Newtonsoft.Json;

namespace FacetedBuilder;

public enum Degree
{
    BTech,
    BCA,
    MCA,
    Medical,
    Witchcarft
}
public enum Year
{
    FirstYear,
    SecondYear,
    ThirdYear,
    FourthYear,
    FifthYear
}

public class Student
{
    //Profile
    public string Name, FatherName, MotherName;
    public DateOnly DateOfBirth;

    //Address
    public string Street, PostalCode, City;

    //Academics
    public string College;
    public Degree Degree;
    public Year Year;

    public override string ToString()
    {
        return JsonConvert.SerializeObject(this);
    }
}

//Facade
public class StudentBuilder
{
    protected Student student;
    public StudentBuilder()
    {
        student = new Student();
    }
    public ProfileBuilder Profile => new ProfileBuilder(student);
    public AddressBuilder Lives => new AddressBuilder(student);
    public AcademicsBuilder Study => new AcademicsBuilder(student);

    public static implicit operator Student(StudentBuilder builder)
    {
        return builder.student;
    }
}

public class ProfileBuilder : StudentBuilder
{
    public ProfileBuilder(Student student)
    {
        this.student = student;
    }
    public ProfileBuilder Called(string name)
    {
        student.Name = name;
        return this;
    }
    public ProfileBuilder ParentsAre(string father, string mother)
    {
        student.FatherName = father;
        student.MotherName = mother;
        return this;
    }
    public ProfileBuilder BornOn(int dd, int mm, int yyyy)
    {
        student.DateOfBirth = new DateOnly(yyyy, mm, dd);
        return this;
    }
}

public class AddressBuilder : StudentBuilder
{
    public AddressBuilder(Student student)
    {
        this.student = student;
    }
    public AddressBuilder At(string street)
    {
        student.Street = street;
        return this;
    }
    public AddressBuilder WithPostcode(string postcode)
    {
        student.PostalCode = postcode;
        return this;
    }
    public AddressBuilder In(string city)
    {
        student.City = city;
        return this;
    }
}

public class AcademicsBuilder : StudentBuilder
{
    public AcademicsBuilder(Student student)
    {
        this.student = student;
    }
    public AcademicsBuilder InCollege(string college)
    {
        student.College = college;
        return this;
    }
    public AcademicsBuilder Persuing(Degree degree)
    {
        student.Degree = degree;
        return this;
    }
    public AcademicsBuilder CurrentYear(Year year)
    {
        student.Year = year;
        return this;
    }
}