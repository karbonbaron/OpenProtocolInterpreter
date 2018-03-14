﻿namespace OpenProtocolInterpreter.Communication
{
    /// <summary>
    /// MID: Application Communication stop
    /// Description:
    ///     This message disables the communication. The controller will stop to respond to any commands
    ///     except for MID 0001 Communication start after receiving this command.
    /// Message sent by: Controller
    /// Answer: MID 0005 Command accepted
    /// </summary>
    public class MID_0003 : MID, ICommunication
    {
        private const int LAST_REVISION = 1;
        public const int MID = 3;

        public MID_0003() : base(MID, LAST_REVISION) { }

        internal MID_0003(IMID nextTemplate) : base(MID, LAST_REVISION) => NextTemplate = nextTemplate;

        public override MID ProcessPackage(string package)
        {
            if (IsCorrectType(package))
                return base.ProcessPackage(package);

            return NextTemplate.ProcessPackage(package);
        }
    }
}
