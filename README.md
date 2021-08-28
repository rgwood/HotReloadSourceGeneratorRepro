# .NET 6 Hot Reload Source Generator Bug

## Steps to reproduce

1. Run `dotnet watch` inside this directory with .NET 6 Preview 7
2. Make a change to Program.cs (ex: change the `$"Hello from thread {threadId}"` interpolated string, save file
3. Observe CS0103 error in console and no change in application behavior

```
error CS0103: The name 'Windows' does not exist in the current context
```
