using System;
using System.Collections.Generic;

namespace AgentInfo
{
    public class Agent
    {

        public Agent(int ag_id, string ag_name)
        {
            id = ag_id;
            name = ag_name;
        }

        public int id;
        public string name;
    }

    public class AgentData
    {
        public AgentData(int ag_id, int t_calls, int h_up)
        {
            AgentId = ag_id;
            TotalCalls = t_calls;
            Hangups = h_up;
        }

        public int AgentId;
        public int TotalCalls;
        public int Hangups;
    }

    class GetAgentInfo
    {
        static List<Agent> CreateAgentList()
        {
            List<Agent> ag_list = new List<Agent>()
            {
                new Agent(1, "Jack"),
                new Agent(2, "Jill"),
                new Agent(3, "Jane"),
                new Agent(4, "Jacob")
        };

            return ag_list;
        }

        static List<AgentData> CreateAgentDataList()
        {
            List<AgentData> ag_data_list = new List<AgentData>
            {
                new AgentData(1, 3, 4),
                new AgentData(2, 4, 5),
                new AgentData(3, 7, 2),
                new AgentData(1, 7, 2)
            };

            return ag_data_list;
        }

        static void Main(string[] args)
        {
            var agents = CreateAgentList();
            var agentdata = CreateAgentDataList();

            Dictionary<int, AgentData> record = new Dictionary<int, AgentData>();

            foreach (var data in agentdata)
            {                
                if (record.TryGetValue(data.AgentId, out AgentData value))
                {
                    record[data.AgentId].TotalCalls += data.TotalCalls;
                    record[data.AgentId].Hangups += data.Hangups;
                }
                else
                {
                    record.Add(data.AgentId, data);
                }

            }

            foreach (var row in record)
            {
                Console.WriteLine("Name: {0}, Id: {1}, TotalCalls: {2}, Hangups: {3}", agents[row.Key].name, row.Value.AgentId, row.Value.TotalCalls, row.Value.Hangups);
            }

        }
    }
}
