namespace WebApplication7.Entities
{
    public class UserTask
    {
        public Guid Id { get; set; }
        public WfType WorkflowType { get; set; }
        public WfStep CurrentWorkflowStep { get; set; }
        public Guid RequestId { get; set; }
        public string AssignTo { get; set; }
        public bool IsClosed { get; set; }
        public WfDesicion Desicion { get; set; }
        public string? Comment { get; set; }

        public void Close(WfDesicion desicion = WfDesicion.Empty, string comment = "")
        {
            Desicion = desicion;
            Comment = comment;
            IsClosed = true;
        }

        public void Validate(List<string> authors)
        {
            if (IsClosed)
                throw new UnauthorizedAccessException();
            if (!authors.Any(c => c == AssignTo))
                throw new UnauthorizedAccessException();
        }
    }
}
