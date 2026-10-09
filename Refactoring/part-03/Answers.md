# Part 03 Answers

## BlockedUsers

- Time complexity before: O(request count * blocked id count)
- Time (ms) before: 18 ms
- What did you change? I converted the blocked ids to a `HashSet<int>` before checking request ids.
- Time complexity after: O(blocked id count + request count)
- Time (ms) after: 1 ms

## Students

- What was the problem? `GetAllStudents` built a list of 1,000,000 students even though the caller only printed the first 3.
- What did you change? I changed it to return `IEnumerable<Student>` and used `yield return`, so students are created only as the caller asks for them.
