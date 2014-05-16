// This file is part of HangFire.
// Copyright � 2013-2014 Sergey Odinokov.
// 
// HangFire is free software: you can redistribute it and/or modify
// it under the terms of the GNU Lesser General Public License as 
// published by the Free Software Foundation, either version 3 
// of the License, or any later version.
// 
// HangFire is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU Lesser General Public License for more details.
// 
// You should have received a copy of the GNU Lesser General Public 
// License along with HangFire. If not, see <http://www.gnu.org/licenses/>.

using System;
using System.Messaging;
using HangFire.Storage;

namespace HangFire.Msmq
{
    internal class MsmqFetchedJob : IFetchedJob
    {
        private readonly MessageQueueTransaction _transaction;

        public MsmqFetchedJob(MessageQueueTransaction transaction, string jobId)
        {
            if (transaction == null) throw new ArgumentNullException("transaction");
            if (jobId == null) throw new ArgumentNullException("jobId");

            _transaction = transaction;

            JobId = jobId;
        }

        public string JobId { get; private set; }

        public void RemoveFromQueue()
        {
            _transaction.Commit();
        }

        public void Dispose()
        {
            _transaction.Dispose();
        }
    }
}