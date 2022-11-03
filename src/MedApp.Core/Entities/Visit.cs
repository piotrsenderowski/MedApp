using MedApp.Core.Exceptions;
using MedApp.Core.ValueObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedApp.Core.Entities
{
    public class Visit
    {
        public VisitId Id { get; private set; }
        public UserId DoctorId { get; private set; }
        public PatientId PatientId { get; private set; }
        public ConsultationRoomId ConsultationRoomId { get; private set; }
        public Date DateFrom_planned { get; private set; }
        public Date DateTo_planned { get; private set; }
        public Date DateFrom_executed { get; private set; }
        public Date DateTo_executed { get; private set; }
        public ProcedureName ProcedureName { get; private set; }
        public Description Description { get; private set; }
        public Status Status { get; private set; }
        public User User { get; set; }
        public Patient Patient { get; set; }
        public ConsultationRoom ConsultationRoom { get; set; }

        public Visit(VisitId id, UserId doctorId,
            PatientId patientId, ConsultationRoomId consultationRoomId,
            ProcedureName procedureName, Description description, Status status,
            Date dateFrom_planned, Date dateTo_planned, Date dateFrom_executed, Date dateTo_executed)
        {
            Id = id;
            DoctorId = doctorId;
            PatientId = patientId;
            ConsultationRoomId = consultationRoomId;
            ProcedureName = procedureName;
            Description = description;
            Status = status;
            DateFrom_planned = dateFrom_planned;
            DateTo_planned = dateTo_planned;
            DateFrom_executed = dateFrom_executed;
            DateTo_executed = dateTo_executed;
        }

        public void Confirm()
        {
            if (Status != Status.Reserved)
            {
                throw new CannotModifyStatusException(Status.Confirmed);
            }
            Status = Status.Confirmed;
        }

        public void Cancel()
        {
            if (Status != Status.Confirmed && Status != Status.Reserved)
            {
                throw new CannotModifyStatusException(Status.Cancelled);
            }
            Status = Status.Cancelled;
        }

        public void Start()
        {
            if (Status != Status.Confirmed && Status != Status.Reserved)
            {
                throw new CannotModifyStatusException(Status.Ongoing);
            }
            DateFrom_executed = DateTime.UtcNow;
            Status = Status.Ongoing;
        }

        public void Finish()
        {
            if (Status != Status.Ongoing)
            {
                throw new CannotModifyStatusException(Status.Completed);
            }
            DateTo_executed = DateTime.UtcNow;
            Status = Status.Completed;
        }
    }
}
namespace RefactoringGuru.DesignPatterns.Strategy.Conceptual
{
    // The Context defines the interface of interest to clients.
    class Context
    {
        // The Context maintains a reference to one of the Strategy objects. The
        // Context does not know the concrete class of a strategy. It should
        // work with all strategies via the Strategy interface.
        private IStrategy _strategy;

        public Context()
        { }

        // Usually, the Context accepts a strategy through the constructor, but
        // also provides a setter to change it at runtime.
        public Context(IStrategy strategy)
        {
            this._strategy = strategy;
        }

        // Usually, the Context allows replacing a Strategy object at runtime.
        public void SetStrategy(IStrategy strategy)
        {
            this._strategy = strategy;
        }

        // The Context delegates some work to the Strategy object instead of
        // implementing multiple versions of the algorithm on its own.
        public void DoSomeBusinessLogic()
        {
            Console.WriteLine("Context: Sorting data using the strategy (not sure how it'll do it)");
            var result = this._strategy.DoAlgorithm(new List<string> { "a", "b", "c", "d", "e" });

            string resultStr = string.Empty;
            foreach (var element in result as List<string>)
            {
                resultStr += element + ",";
            }

            Console.WriteLine(resultStr);
        }
    }

    // The Strategy interface declares operations common to all supported
    // versions of some algorithm.
    //
    // The Context uses this interface to call the algorithm defined by Concrete
    // Strategies.
    public interface IStrategy
    {
        object DoAlgorithm(object data);
    }

    // Concrete Strategies implement the algorithm while following the base
    // Strategy interface. The interface makes them interchangeable in the
    // Context.
    class ConcreteStrategyA : IStrategy
    {
        public object DoAlgorithm(object data)
        {
            var list = data as List<string>;
            list.Sort();

            return list;
        }
    }

    class ConcreteStrategyB : IStrategy
    {
        public object DoAlgorithm(object data)
        {
            var list = data as List<string>;
            list.Sort();
            list.Reverse();

            return list;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // The client code picks a concrete strategy and passes it to the
            // context. The client should be aware of the differences between
            // strategies in order to make the right choice.
            var context = new Context();

            Console.WriteLine("Client: Strategy is set to normal sorting.");
            context.SetStrategy(new ConcreteStrategyA());
            context.DoSomeBusinessLogic();

            Console.WriteLine();

            Console.WriteLine("Client: Strategy is set to reverse sorting.");
            context.SetStrategy(new ConcreteStrategyB());
            context.DoSomeBusinessLogic();
        }
    }
}
