using System;
using System.Collections.Generic;
using System.Linq;

namespace Kubernetes
{
    public class Controller : IController
    {
        private Dictionary<string, Pod> pods;

        public Controller()
        {
            pods = new Dictionary<string, Pod>();
        }

        public bool Contains(string podId)
            => this.pods.ContainsKey(podId);

        public int Size()
            => this.pods.Count;

        public void Deploy(Pod pod)
        {
            if (!this.Contains(pod.Id))
            {
                this.pods.Add(pod.Id, pod);
            }
        }

        public Pod GetPod(string podId)
        {
            if (!this.Contains(podId))
            {
                throw new ArgumentException();
            }
            
            return this.pods[podId];
        }

        public void Uninstall(string podId)
        {
            if (!this.Contains(podId))
            {
                throw new ArgumentException();
            }

            this.pods.Remove(podId);
        }

        public void Upgrade(Pod pod)
        {
            if (Contains(pod.Id))
            {
                pods[pod.Id] = pod;
            }
            else
            {
                Deploy(pod);
            }
        }

        public IEnumerable<Pod> GetPodsBetweenPort(int lowerBound, int upperBound)
            => this.pods.Values
                .Where(p => p.Port >= lowerBound && p.Port <= upperBound);

        public IEnumerable<Pod> GetPodsInNamespace(string @namespace)
            => this.pods.Values
                .Where(p => p.Namespace == @namespace);

        public IEnumerable<Pod> GetPodsOrderedByPortThenByName()
            => this.pods.Values
                .OrderByDescending(p => p.Port)
                .ThenBy(p => p.Namespace);
    }
}