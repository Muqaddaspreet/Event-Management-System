using System;
using System.Collections.Generic;
using System.Text;

namespace BookReadingEvent.Core.ValueObjects
{
    public sealed class Message: ValueObject<Message>
    {
        #region Ctor
        /// <summary>
        /// Initializes a new instance of the <see cref="Message"/> class.
        /// </summary>
        /// <param name="code">The code.</param>
        /// <param name="text">The text.</param>
        /// <param name="localizedText">The localized text.</param>
        /// <param name="members">The members.</param>
        public Message(string code, string text, string localizedText, IList<string> members)
        {
            this.Code = code;
            this.Text = text;
            this.LocalizedText = localizedText;
            this.Members = members;
        }
        public Message(string code, string text, string localizedText)
        {
            this.Code = code;
            this.Text = text;
            this.LocalizedText = localizedText;

        }
        public Message(string code, string text)
        {
            this.Code = code;
            this.Text = text;

        }
        #endregion

        /// <summary>
        /// Gets the code.
        /// </summary>
        /// <value>
        /// The code.
        /// </value>

        public string Code { get; private set; }

        /// <summary>
        /// Gets the text.
        /// </summary>
        /// <value>
        /// The text.
        /// </value>

        public string Text { get; private set; }

        /// <summary>
        /// Gets the localized text.
        /// </summary>
        /// <value>
        /// The localized text.
        /// </value>

        public string LocalizedText { get; private set; }

        /// <summary>
        /// Gets the members.
        /// TODO: Make it readonly list
        /// </summary>
        /// <value>
        /// The members.
        /// </value>

        public IList<string> Members { get; private set; }

        /// <summary>
        /// Called when [equals].
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        protected override bool OnEquals(Message item)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Called when [get hash code].
        /// </summary>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        protected override int OnGetHashCode()
        {
            throw new NotImplementedException();
        }
    }
}
