using Microsoft.AspNetCore.Mvc;

namespace itijuana.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MidLevelExerciseController : ControllerBase
    {
        public MidLevelExerciseController()
        {

        }

        [HttpPost("GetIntegersThatDoNotAppearInRangeOfIntegers")]
        public Response<int[]> GetIntegersThatDoNotAppearInRangeOfIntegers(int[] range)
        {
            List<int> result = new List<int>();

            HashSet<int> hash = range.ToHashSet();

            if (hash != null && hash.Count > 1)
            {
                for (int i = 0; i < range.Length; i++)
                {
                    int num = i + 1;

                    if (!hash.Contains(num))
                    {
                        result.Add(num);
                    }
                }
            }

            return new Response<int[]>
            {
                Result = result?.ToArray(),
                Count = result?.Count
            };
        }

        [HttpPost("IndicesOfTwoNumbersThatTheyAddUpToTarget")]
        public Response<int[]> IndicesOfTwoNumbersThatTheyAddUpToTarget(int[] range, int target)
        {
            Dictionary<int, int> hash = new Dictionary<int, int>();

            for (int j = 0; j < range.Length; j++)
            {
                if (hash.ContainsKey(target - range[j]))
                {
                    return new Response<int[]>
                    {
                        Result = new int[] { hash[target - range[j]], j }
                    };
                }
                else
                {
                    hash.TryAdd(range[j], j);
                }
            }

            return new Response<int[]>
            {
                Error = "No combination of numbers add up to target."
            };
        }



    }
}