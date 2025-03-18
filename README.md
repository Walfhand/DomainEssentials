# DomainEssentials

A .NET 9 library providing essential components for implementing Domain-Driven Design (DDD) in your applications.

## About

DomainEssentials is a lightweight library that offers the fundamental building blocks for constructing applications following Domain-Driven Design principles. It provides abstractions and implementations for key DDD concepts such as entities, aggregates, domain events, and more.

## Features

- **Aggregates and Entities**: Base implementations for aggregates and entities with typed ID support
- **Domain Events**: Infrastructure for domain event management
- **Auditing**: Built-in support for audit information (creation, modification, deletion)
- **Domain Exceptions**: Base classes for domain-specific exceptions

## Usage

### Creating an Entity

```csharp
public class UserId : IdBase { }

public class User : Entity<UserId>
{
    public string Username { get; private set; }
    public string Email { get; private set; }

    private User() { } // For ORM

    public User(string username, string email)
    {
        Username = username;
        Email = email;
    }
}
```

### Creating an Aggregate Root

```csharp
public class OrderId : IdBase { }

public class Order : AggregateRoot<OrderId>
{
    private readonly List<OrderItem> _items = [];
    public IReadOnlyList<OrderItem> Items => _items.AsReadOnly();

    private Order() { } // For ORM

    public Order(Customer customer)
    {
        // Creation logic
        AddDomainEvent(new OrderCreatedEvent(this));
    }

    public void AddItem(Product product, int quantity)
    {
        // Business logic
        _items.Add(new OrderItem(product, quantity));
        AddDomainEvent(new OrderItemAddedEvent(this, product, quantity));
    }
}
```

## Requirements

- .NET 9.0

## Installation

Add a reference to the project in your solution or install the package via NuGet (coming soon).

## License

This project is licensed under the MIT License.
