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

	public static void Dijkstra<Vertex, Edge, Mark>(
		Map<Vertex, int> reachedStates, 
		Vertex start, 
		Func<Vertex, IEnumerable<Edge>> getEdgesFrom,
		Func<Edge, int> weight,
		Func<Edge, Vertex> to,
		Map<Vertex, Pair<Vertex, Mark>> solution = null,
		Func<Edge, Mark> mark = null
	) {
		var queue = new PriorityQueue<Pair<Vertex, int>>(less: (a,b) => a.second < b.second);
		queue.Enqueue(new Pair<Vertex, int>(start, 0));

		var distances = new Map<Vertex, int>(defaultValueProvider: () => int.MaxValue);

		if (solution == null) {
			solution = new Map<Vertex, Pair<Vertex, Mark>>();
		}

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

			getEdgesFrom(element.first).ToList().ForEach(edge => {
				var newDistance = element.second + weight(edge);
				if (newDistance < distances[to(edge)]) {
					distances[to(edge)] = newDistance;
					solution[to(edge)] = new Pair<Vertex, Mark>(element.first, mark(edge));
					queue.Enqueue(new Pair<Vertex, int>(to(edge), newDistance));
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
