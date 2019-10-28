using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CFATestFrederick.Data;

namespace CFATestFrederick.Service
{
    public class StreamService : IStreamService
    {
        private readonly IStreamRepository<String> _streamRepository;
        public StreamService (IStreamRepository<String> repository)
        {
            _streamRepository = repository;
        }

        public int getScore(int inputIndex)
        {
            String input = _streamRepository.GetByIndex(inputIndex);

            Stack<Char> characters = new Stack<Char>();
            Boolean inGarbage = false;
            Boolean shouldSkip = false;
            int completedPair = 0;
            int score = 0;

            for (int i = 0; i < input.Length; i ++)
            {
                Char curr = input[i];

                if (shouldSkip)
                {
                    shouldSkip = false;
                    continue;
                }
                else if (curr == '>')
                {
                    inGarbage = false;
                    continue;
                }
                else if (inGarbage)
                {
                    if (curr == '!')
                    {
                        shouldSkip = true;
                        continue;
                    }
                    continue;
                }
                else if (curr == '!')
                {
                    shouldSkip = true;
                    continue;
                }
                else if (curr == '<')
                {
                    inGarbage = true;
                    continue;
                }
                else if (curr == '{')
                {
                    characters.Push(curr);
                    continue;
                }
                else if (curr == '}')
                {
                    if (characters.Count == 0)
                    {
                        return -1;
                    }
                    score += characters.Count();
                    completedPair++;
                    characters.Pop();
                }
            }

            if (characters.Count() > 0)
            {
                return -1;
            }
            
            return score;
        }
    }
}
