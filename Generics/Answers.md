# Generics Answers

## Step 2 - StudentStore and CourseStore

The two stores have the same behavior: add an item, get one item by id, return all items, and remove an item by id. The only real difference is the type stored inside each class: one works with `Student`, and the other works with `Course`.

That repeated structure is the reason a generic store is a better design.

## Step 3 - Why Store<T> Does Not Compile Yet

When `Store<T>` first works with any possible `T`, the compiler does not know that `T` has an `Id` property.

The expected compiler error is:

```text
'T' does not contain a definition for 'Id'
```

The compiler rejects it because generic type parameters only allow members that are guaranteed by their constraints. Without a constraint, `T` could be `string`, `int`, or any other type that has no `Id`.

## Step 7 - Why Store<string>() Must Not Compile

`Store<T>` has the constraint `where T : IHasId`. `Student` and `Course` compile because both implement `IHasId`. `string` does not implement that interface, so `new Store<string>()` must fail at compile time.

## Last Question

The common name for the kind of class built in Steps 4 and 5 is a generic repository.
