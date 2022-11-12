using System;

namespace BookReadingEvent.Core.Data
{
    public static class Constants
    {
        public struct SQLErrorCodes
        {
            /// <summary>
            /// The foreign constraint violation
            /// </summary>
            public const int ForeignConstraintViolation = 547;

            /// <summary>
            /// The duplicate key row insertion
            /// </summary>
            public const int DuplicateKeyRowInsertion = 2601;

            /// <summary>
            /// The unique constraint violation
            /// </summary>
            public const int UniqueConstraintViolation = 2627;

        }
        /// <summary>
        /// TODO: Store and get messages resource files
        /// </summary>
        public struct SQLServerErrorMessageTemplate
        {
            /// <summary>
            /// The foreign constraint violation
            /// </summary>
            public const string ForeignConstraintViolation = "The #statement conflicted with the #constraint #\". The conflict occurred in database #, table #, column #. The statement has been terminated.";

            /// <summary>
            /// The duplicate key row insertion
            /// </summary>
            public const string DuplicateKeyRowInsertion = "Cannot insert duplicate key row in object #with unique index #. The duplicate key value is #.The statement has been terminated.";

            /// <summary>
            /// The unique constraint violation
            /// </summary>
            public const string UniqueConstraintViolation = "";
        }
    }
}
