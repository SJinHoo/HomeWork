namespace ShortestPathPractice
{
    internal class Dijkstra
    {
        const int INF = 99999;    // 오버플로우 방지를 위해 큰 값을 넣어줌

        public static void ShortestPath(int[,] graph, int start, out int[] cost, out int[] path)
        {
            int size = graph.GetLength(0);      // 그래프 가져오기
            bool[] visited = new bool[size];    // 방문 여부를 판별하기 위한 visited 

            cost = new int[size];               // 최단 거리의 결과 갯수
            path = new int[size];               // 최단 경로의 결과 갯수
           
            for (int i = 0; i < size; i++)      // 맨 처음 값 설정
            {
                cost[i] = graph[start, i];      // 시작지점으로 부터 연결이 되어있는 거리의 cost
                path[i] = graph[start, i] < INF ? start : -1;       // 시작지점부터 연결되어 있는 거리가 INF 보다 작으면 start 그 외의 경우 -1
                                                                    // 
            }

            for(int i = 0; i < size; i++)
            {
                int next = -1;
                int minCost = INF;

                // 1. 방문하지 않은 정점 중 가장 가까운 정점부터 탐색
                for(int j = 0; j < size; j++)
                {
                    if (!visited[j] && cost[j] < minCost) // 방문하지 않은 정점중에서 계속해서 최소값을 갱신하며
                    {
                        next = j;                         // next에 가장 작은 정점
                        minCost = cost[j];                // mincost에 가장작은 정점의 최소값
                    }
                }
                if (next < 0) break;

                // 2. 직접 연결된 거리보다 거쳐서 연결된 거리가 더 짧아진다면 갱신

                for(int j =0; j < size; j++)
                {
                    // cost[j] : 목적지 까지 직접 연결된 거리
                    // distance[next] : 탐색중인 정점까지 거리
                    // graph [next, j] : 탐색중인 정점부터 목적지의 거리

                    // 직접연결된 거리가 next를 거쳐서 가는 거리보다 더 큰 경우 갱신
                    if (cost[j] > cost[next] + graph[next, j]) 
                    {
                        cost[j] = cost[next] + graph[next, j];
                        path[j] = next;
                    }
                }
                // 탐색이 완료된 정점의 경우 방문을 했다는 확인으로 true 입력
                visited[next] = true;
            }
        }
    }
}
