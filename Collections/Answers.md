# Collections Answers

## Task 2.1 - Research

### IReadOnlyDictionary<TKey, TValue>

`IReadOnlyDictionary<TKey, TValue>` is an interface for a key/value collection that callers can read from without being given methods such as `Add`, `Remove`, or `Clear`. It is useful as a public return type when the owner of the data wants to expose lookup behavior while keeping control over changes.

It is different from `Dictionary<TKey, TValue>` because `Dictionary` is a concrete mutable collection. If a public method returns `Dictionary`, the caller can change the returned collection. Returning `IReadOnlyDictionary` communicates that the caller should read the values only.

### SortedDictionary<TKey, TValue>

`SortedDictionary<TKey, TValue>` stores key/value pairs ordered by key. A regular `Dictionary` is optimized for fast lookup and does not guarantee sorted output by key. `SortedDictionary` keeps the keys sorted as items are added, which makes it useful when the program needs ordered iteration.

Lookup in a regular `Dictionary` is usually O(1). Lookup in a `SortedDictionary` is O(log n), because it maintains sorted order. I would choose `SortedDictionary` when the data must stay sorted by key while still supporting lookup by key.

## Task 2.2 - Pick the Collection

| Scenario | Collection | Reason |
| --- | --- | --- |
| S1 | `Dictionary` | A national ID is a key, and dictionary lookup is fast for repeated searches. |
| S2 | `HashSet` | A set stores unique values, so duplicate tags are rejected naturally. |
| S3 | `List` | A list preserves insertion order and allows repeated grades. |
| S4 | `IReadOnlyDictionary` | Callers can read prices by key without being allowed to change the collection through the public API. |
| S5 | `SortedDictionary` | The timetable is keyed by start time and must stay sorted while sessions are added. |
| S6 | `IEnumerable` | The caller only needs to loop over the results and may stop early. |
