# SOLID Principles
- Design princples introduced by Robert C. Martin
- Frequently references in Design Pattern literature
- Compose of 5 different priciples:
  - Single Responsibility Principle
  - Open-Closed Principle
  - Liskov Substitution Principle
  - Interface Segregation Principle
  - Dependency Inversion Principle
 
  # Single Responsibility Principle
Single Responsibility Principle says, "Every software module should have only one reason to change.".</br>
This means that every class or similar structure in your code should have only one job. Everything in that class should be related to a single purpose. It does not mean that your classes should only contain one method or property. There may be many members as long as they relate to a single responsibility.

# Open-Closed Principle
The Open/closed Principle says, "A software module/class is open for extension and closed for modification." </br>

Here "Open for extension" means we must design our module/class so that the new functionality can be added only when new requirements are generated. "Closed for modification" means we have already developed a class, and it has gone through unit testing. We should then not alter it until we find bugs. As it says, a class should be open for extensions; we can use inheritance. 