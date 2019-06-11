# GraphQl
Simple demo for GraphQl using ASP.NET. Provides a GraphQL controller which can be used as endpoint for ChromeiQL. Uses the graphql-dotnet package.

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
}```
