using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Cli
{
  public static class PipeliningExtensions
  {
    public static TOutput Pipe<TInput, TOutput>(
      this TInput input,
      Func<TInput, TOutput> filter) =>
      filter(input);

    public static T Pipe<T>(this T input, Action<T> action)
    {
      action(input);
      return input;
    }

    public static IEnumerable<T> Pipe<T>(
      this IEnumerable<T> input,
      Action<T> action) =>
      input.Select(x =>
      {
        action(x);
        return x;
      });

    public static IEnumerable<TOutput> Pipe<TInput, TOutput>(
      this IEnumerable<TInput> input,
      Func<TInput, TOutput> filter,
      int degreeOfParallelism) =>
      input
        .AsParallel()
        .WithDegreeOfParallelism(degreeOfParallelism)
        .Select(filter);

    public static void Run<T>(this IEnumerable<T> target) =>
      target.GetEnumerator().RunToEnd();

    private static void RunToEnd(this IEnumerator enumerator)
    {
      while (enumerator.MoveNext()) ;
    }
  }
}
