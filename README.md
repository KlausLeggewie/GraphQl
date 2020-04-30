# GraphQl

Simple demo for GraphQL using ASP.NET Core. Provides a GraphQL endpoint which can be used for GraphQL clients like ChromeiQL. 
Uses the graphql-dotnet package.

## Examples

1. GraphQL **query** (based on the test-data included):
```query {
  employee(isActive: true) {
    id
    firstName
    lastName
    age
    isActive
    gender
  }
}
```
2. GraphQL **mutation**

```mutation createEmployeeExample {
  createEmployee(firstName: "Donald", lastName: "Duck", age: 11, gender: "male", isActive: true) {
    id
    firstName
    lastName
    age
    gender
    isActive
  }
}
```

More examples are shown the on index view of the web project.