# GraphQl
Simple demo for GraphQL using ASP.NET Core. Provides a GraphQL endpoint which can be used for GraphQL clients like ChromeiQL. 
Uses the graphql-dotnet package.

GraphQL query example (based on the test-data included):
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
More examples are in the solution.