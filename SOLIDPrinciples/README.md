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

# Liskov Substitution Principle
The Liskov Substitution Principle (LSP) states, "you should be able to use any derived class instead of a parent class and have it behave in the same manner without modification.". It ensures that a derived class does not affect the behavior of the parent class; in other words, a derived class must be substitutable for its base class. </br>

This principle is just an extension of the Open Closed Principle, and we must ensure that newly derived classes extend the base classes without changing their behavior. I will explain this with a real-world example that violates LSP.

# Interface Segregation Principle
The Interface Segregation Principle states "that clients should not be forced to implement interfaces they don't use. Instead of one fat interface, many small interfaces are preferred based on groups of methods, each serving one submodule.".

# Dependency Inversion Principle
The Dependency Inversion Principle (DIP) states that high-level modules/classes should not depend on low-level modules/classes. First, both should depend upon abstractions. Secondly, abstractions should not rely upon details. Finally, details should depend upon abstractions.

# Summary
- Single Resposibility Principle
	- A class should only have one reason to change
	- Separation of concerns - different class handling different, independent task/problems
- Open-CLose Principle
	- Class should be open for extension but closed for modification.
- Liskov Substitution Principle
	- You should be able to substitute a base type for a subtype.
- Interface Segregation Principle
	- Don't put too much into an interface; split into separte interface
	- YAGNI - You Ain't Going to Need it.
- Dependency Inversion Principle
	- High level modules should not depend o=upon low-level ones; use abstractions.