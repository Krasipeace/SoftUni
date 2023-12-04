using System.Collections.Generic;

namespace Exam.Discord
{
    public interface IDiscord
    {
        void SendMessage(Message message);

        bool Contains(Message message);

        int Count { get; }

        Message GetMessage(string messageId);

        void DeleteMessage(string messageId);

        void ReactToMessage(string messageId, string reaction);

        IEnumerable<Message> GetChannelMessages(string channel);

        IEnumerable<Message> GetMessagesByReactions(List<string> reactions);

        IEnumerable<Message> GetMessageInTimeRange(int lowerBound, int upperBound);

        IEnumerable<Message> GetTop3MostReactedMessages();

        IEnumerable<Message> GetAllMessagesOrderedByCountOfReactionsThenByTimestampThenByLengthOfContent();
    }
}
