using FinancialDocument.Service.Commands;
using Swashbuckle.AspNetCore.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinancialDocument.Api.Examples.Document
{

    public class DocumentAddCommandExample : IMultipleExamplesProvider<DocumentAddCommand>
    {
        public IEnumerable<SwaggerExample<DocumentAddCommand>> GetExamples()
        {
            yield return SwaggerExample.Create(
                "Financial document - Debit",
                new DocumentAddCommand()
                {
                    DocumentNumber = "Doc.Pay.33123",
                    BusinessPartnerId = Guid.Parse("6d357424-cf26-4efc-8723-b92c4ed4ca1b"),
                    DocumentType = "D",
                    IssueDate = DateTime.Now,
                    DueDate = DateTime.Now.AddDays(10),
                    Amount = 580.25,
                    PaymentMethodId = Guid.Parse("d997816b-163a-4d98-9194-0603612bcc79"),
                    ReceivingLocationId = Guid.Parse("5f5261df-1bb2-4f0b-a901-9cf15dd8ca44"),
                    Observation = "Purchase of supplements",
                    Active = true,
                    Settled = false,
                    documentDetails = new List<DocumentDetailAddCommand>() {
                        new DocumentDetailAddCommand() {
                            //DocumentId = Guid.Empty,
                            OperationType = "D",
                            Date = DateTime.Now.AddDays(10),
                            Value = 580.25,
                            Observation = "Advance payment",
                            Active = true
                        },
                        new DocumentDetailAddCommand() {
                            //DocumentId = Guid.Empty,
                            OperationType = "C",
                            Date = DateTime.Now,
                            Value = 250,
                            Observation = "Advance payment",
                            Active = true
                        }
                    }
                }
            );

            yield return SwaggerExample.Create(
                "Financial document - Credit",
                new DocumentAddCommand()
                {
                    DocumentNumber = "Doc.Rec.18554",
                    BusinessPartnerId = Guid.Parse("42813041-f6e0-49e3-93b7-4d1400b0c7b6"),
                    DocumentType = "C",
                    IssueDate = DateTime.Now,
                    DueDate = DateTime.Now.AddDays(15),
                    Amount = 890.00,
                    PaymentMethodId = Guid.Parse("d997816b-163a-4d98-9194-0603612bcc79"),
                    ReceivingLocationId = Guid.Parse("5f5261df-1bb2-4f0b-a901-9cf15dd8ca44"),
                    Observation = "Product sale",
                    Active = true,
                    Settled = false,
                    documentDetails = new List<DocumentDetailAddCommand>() {
                        new DocumentDetailAddCommand() {
                            //DocumentId = Guid.Empty,
                            OperationType = "C",
                            Date = DateTime.Now.AddDays(5),
                            Value = 445,
                            Observation = "Installment 1",
                            Active = true
                        },
                        new DocumentDetailAddCommand() {
                            //DocumentId = Guid.Empty,
                            OperationType = "C",
                            Date = DateTime.Now.AddDays(15),
                            Value = 445,
                            Observation = "Installment 2",
                            Active = true
                        }
                    }
                }
            );

            yield return SwaggerExample.Create(
                "Financial document - Settled",
                new DocumentAddCommand()
                {
                    DocumentNumber = "Doc.Pay.1224",
                    BusinessPartnerId = Guid.Parse("6d357424-cf26-4efc-8723-b92c4ed4ca1b"),
                    DocumentType = "D",
                    IssueDate = DateTime.Now.AddDays(-60),
                    DueDate = DateTime.Now.AddDays(-30),
                    Amount = 850.50,
                    PaymentMethodId = Guid.Parse("d997816b-163a-4d98-9194-0603612bcc79"),
                    ReceivingLocationId = Guid.Parse("5f5261df-1bb2-4f0b-a901-9cf15dd8ca44"),
                    Observation = "Purchase of supplements",
                    Settled = true,
                    Active = true,
                    documentDetails = new List<DocumentDetailAddCommand>() {
                        new DocumentDetailAddCommand() {
                            //DocumentId = Guid.Empty,
                            OperationType = "D",
                            Date = DateTime.Now.AddDays(-60),
                            Value = 250,
                            Observation = "Installment 1",
                            Active = true
                        },
                        new DocumentDetailAddCommand() {
                            //DocumentId = Guid.Empty,
                            OperationType = "C",
                            Date = DateTime.Now.AddDays(-60),
                            Value = 250,
                            Observation = "Payment 1",
                            Active = true
                        },
                        new DocumentDetailAddCommand() {
                            //DocumentId = Guid.Empty,
                            OperationType = "D",
                            Date = DateTime.Now.AddDays(-40),
                            Value = 300,
                            Observation = "Installment 2",
                            Active = true
                        },
                        new DocumentDetailAddCommand() {
                            //DocumentId = Guid.Empty,
                            OperationType = "C",
                            Date = DateTime.Now.AddDays(-40),
                            Value = 300,
                            Observation = "Payment 2",
                            Active = true
                        },
                        new DocumentDetailAddCommand() {
                            //DocumentId = Guid.Empty,
                            OperationType = "D",
                            Date = DateTime.Now.AddDays(-30),
                            Value = 300.5,
                            Observation = "Installment 3",
                            Active = true
                        },
                        new DocumentDetailAddCommand() {
                            //DocumentId = Guid.Empty,
                            OperationType = "C",
                            Date = DateTime.Now.AddDays(-30),
                            Value = 300.5,
                            Observation = "Payment 3",
                            Active = true
                        },

                    }
                }
            );

        }
    }

    public class DocumentUpdateCommandExample : IMultipleExamplesProvider<DocumentUpdateCommand>
    {
        Guid id = Guid.NewGuid();

        public IEnumerable<SwaggerExample<DocumentUpdateCommand>> GetExamples()
        {

            yield return SwaggerExample.Create(
                "Financial document - Any type",
                new DocumentUpdateCommand()
                {
                    Id = id,
                    DocumentNumber = "Doc.15936",
                    BusinessPartnerId = Guid.Parse("6d357424-cf26-4efc-8723-b92c4ed4ca1b"),
                    DocumentType = "D",
                    IssueDate = DateTime.Now,
                    DueDate = DateTime.Now.AddDays(10),
                    Amount = 580.25,
                    PaymentMethodId = Guid.Parse("d997816b-163a-4d98-9194-0603612bcc79"),
                    ReceivingLocationId = Guid.Parse("5f5261df-1bb2-4f0b-a901-9cf15dd8ca44"),
                    Observation = "Purchase of supplements",
                    Active = true,
                    Settled = false,
                    documentDetails = new List<DocumentDetailUpdate>() {
                        new DocumentDetailUpdate() {
                            DocumentId = id,
                            OperationType = "D",
                            Date = DateTime.Now.AddDays(10),
                            Value = 580.25,
                            Observation = "Advance payment",
                            Active = true
                        },
                        new DocumentDetailUpdate() {
                            DocumentId = id,
                            OperationType = "C",
                            Date = DateTime.Now,
                            Value = 250,
                            Observation = "Advance payment",
                            Active = true
                        }
                    }
                }
            );

        }
    }
}
