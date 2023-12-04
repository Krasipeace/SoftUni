using System;
using System.Collections.Generic;
using System.Linq;

namespace Exam.Discord
{
    public class Discord : IDiscord
    {
        private Dictionary<string, Message> messages;
        private Dictionary<string, List<Message>> channelMessages;

        public Discord()
        {
            this.messages = new Dictionary<string, Message>();
            this.channelMessages = new Dictionary<string, List<Message>>();
        }

        public int Count 
            => this.messages.Count;

        public bool Contains(Message message)
            => this.messages.ContainsKey(message.Id);

        public void SendMessage(Message message)
        {
            this.messages.Add(message.Id, message);

            if (!channelMessages.ContainsKey(message.Channel))
            {
                this.channelMessages.Add(message.Channel, new List<Message>());
            }

            this.channelMessages[message.Channel].Add(message);
        }

        public void DeleteMessage(string messageId)
        {
            if (!this.messages.ContainsKey(messageId))
            {
                throw new ArgumentException();
            }

            var messageToDeleteInChannel = this.channelMessages[this.messages[messageId].Channel]
                .FirstOrDefault(m => m.Id == messageId);

            if (messageToDeleteInChannel == null)
            {
                throw new ArgumentException();
            }
            else
            {
                this.channelMessages[this.messages[messageId].Channel].Remove(messageToDeleteInChannel);
            }

            this.messages.Remove(messageId);
        }

        public Message GetMessage(string messageId)
        {
            if (!this.messages.ContainsKey(messageId))
            {
                throw new ArgumentException();
            }

            return this.messages[messageId];
        }

        public IEnumerable<Message> GetAllMessagesOrderedByCountOfReactionsThenByTimestampThenByLengthOfContent()
            => this.messages.Values
                .OrderByDescending(m => m.Reactions.Count)
                .ThenBy(m => m.Timestamp)
                .ThenBy(m => m.Content.Length)
                .ToList();

        public IEnumerable<Message> GetChannelMessages(string channel)
        {
            if (!this.channelMessages.ContainsKey(channel))
            {
                throw new ArgumentException();
            }

            return this.channelMessages[channel];
        }

        public IEnumerable<Message> GetMessageInTimeRange(int lowerBound, int upperBound)
            => this.messages.Values
                .Where(m => m.Timestamp >= lowerBound && m.Timestamp <= upperBound)
                .OrderByDescending(m => m.Channel)
                .ToList();

        public IEnumerable<Message> GetMessagesByReactions(List<string> reactions)
            => this.messages.Values
                .Where(m => m.Reactions.Intersect(reactions).Any())
                .OrderByDescending(m => m.Reactions.Count)
                .ThenByDescending(m => m.Timestamp)
                .ToList();

        public IEnumerable<Message> GetTop3MostReactedMessages()
            => this.messages.Values
                .OrderByDescending(m => m.Reactions.Count)
                .Take(3)
                .ToList();

        public void ReactToMessage(string messageId, string reaction)
        {
            if (!this.messages.ContainsKey(messageId))
            {
                throw new ArgumentException();
            }

            this.messages[messageId].Reactions.Add(reaction);
        }
    }
}
