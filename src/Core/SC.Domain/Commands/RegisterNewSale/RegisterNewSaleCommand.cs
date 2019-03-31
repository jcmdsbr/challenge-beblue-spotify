using System;
using System.Collections.Generic;
using SC.Core.Commands;
using SC.Domain.ValueObjects;

namespace SC.Domain.Commands.RegisterNewSale
{
    public class RegisterNewSaleCommand : ICommand<RegisterNewSaleCommandResult>
    {
        public RegisterNewSaleCommand(IReadOnlyCollection<Guid> playlists, Cpf customerCpf)
        {
            Playlists = playlists;
            CustomerCpf = customerCpf;
        }

        public IReadOnlyCollection<Guid> Playlists { get; }
        public Cpf CustomerCpf { get; }
    }
}