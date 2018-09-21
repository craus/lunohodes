using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;

public class Algorithms
{
    public static void Dfs<StateType>(HashSet<StateType> reachedStates, StateType start, Func<StateType, IEnumerable<StateType>> getNextStates) {
        if (reachedStates.Contains(start)) {
            return;
        }
        reachedStates.Add(start);
        getNextStates(start).ToList().ForEach(nextState => {
            Dfs(reachedStates, nextState, getNextStates);
        });
    }

    public static HashSet<StateType> Reachable<StateType>(StateType start, Func<StateType, IEnumerable<StateType>> getNextStates, IEqualityComparer<StateType> comparer = null) {
        var result = new HashSet<StateType>(comparer ?? EqualityComparer<StateType>.Default);
        Dfs(result, start, getNextStates);
        return result;
    }

	public static void Dijkstra<StateType>(
		Map<StateType, int> reachedStates, 
		StateType start, 
		Func<StateType, IEnumerable<Pair<StateType, int>>> getNextStates
	) {
		var queue = new PriorityQueue<Pair<StateType, int>>(less: (a,b) => a.second < b.second);
		queue.Enqueue(new Pair<StateType, int>(start, 0));

		var distances = new Map<StateType, int>(defaultValueProvider: () => int.MaxValue);

		int cnt = 1000;
		while (queue.Count() > 0) {
			cnt--;
			if (cnt < 0) {
				break;
			}
			var element = queue.Dequeue();
			if (reachedStates.ContainsKey(element.first)) {
				continue;
			}
			reachedStates.Add(element.first, element.second);

			getNextStates(element.first).ToList().ForEach(nextState => {
				var newDistance = element.second + nextState.second;
				if (newDistance < distances[nextState.first]) {
					distances[nextState.first] = newDistance;
					queue.Enqueue(new Pair<StateType, int>(nextState.first, newDistance));
				}
			});
		}
	}

    public static void Bfs<StateType>(
        HashSet<StateType> reachedStates, 
        StateType start, 
        Func<StateType, IEnumerable<StateType>> getNextStates
    ) {
        Queue<StateType> queue = new Queue<StateType>();
        queue.Enqueue(start);
        reachedStates.Add(start);
        while (queue.Count > 0) {
            getNextStates(queue.Dequeue()).ToList().ForEach(nextState => {
                if (!reachedStates.Contains(nextState)) {
                    reachedStates.Add(nextState);
                    queue.Enqueue(nextState);
                }
            });
        }
    }

    public static float BinarySearch(float min, float max, Predicate<float> smallEnough, float eps = 1e-4f) {
        var current = min;
        var step = (max - min) / 2;
        while (step > eps) {
            if (smallEnough(current + step)) {
                current += step;
            }
            step /= 2;
        }
        return current;
    }
}
