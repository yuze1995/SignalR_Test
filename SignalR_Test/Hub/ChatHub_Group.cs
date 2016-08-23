using Microsoft.AspNet.SignalR;
using SignalR_Test.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace SignalR_Test
{
    public class ChatHub_Group : Hub
    {
        private DBContext db = new DBContext();

        public void CreateRoom(string roomName, string name)
        {
            Groups.Add(Context.ConnectionId, roomName);

            db.Groups.Add(new Groups { groupName = roomName });
            db.Members.Add(new Members
            {
                name = name,
                groupName = roomName
            });
            db.SaveChanges();

            Clients.All.updateRoom(db.Groups.Select(p => new { p.groupName }).ToList());
        }

        public void GetRoomList()
        {
            var data = db.Groups.Select(p => new { p.groupName }).ToList();
            Clients.Client(this.Context.ConnectionId).updateRoom(data);
        }

        public void GetMemberList(string room)
        {
            var members = db.Members.Where(p => p.groupName.Equals(room)).Select(p => p.name).ToList();
            Clients.Client(this.Context.ConnectionId).updateMember(members);
        }

        public void JoinRoom(string roomName, string name)
        {
            Groups.Add(Context.ConnectionId, roomName);

            db.Members.Add(new Members { groupName = roomName, name = name });
            db.SaveChanges();
            var members = db.Members.Where(p => p.groupName.Equals(roomName)).Select(p => new { p.name }).ToList();

            Clients.Group(roomName).sayHello(members, roomName, name);
        }

        public void LeaveRoom(string roomName, string name)
        {
            Groups.Remove(Context.ConnectionId, roomName);
            
            var members = db.Members.FirstOrDefault(p => p.groupName.Equals(roomName));
            db.Members.Remove(members);
            db.SaveChanges();

            Clients.Group(roomName).SayGoodBye(name);
        }

        public void SendMessage(string roomName, string name, string msg)
        {
            Clients.Group(roomName).addMessage(name, msg);
        }

        public void RemoveData()
        {
            var memberData = db.Members.ToList();
            var groupData = db.Groups.ToList();
            db.Members.RemoveRange(memberData);
            db.Groups.RemoveRange(groupData);
            db.SaveChanges();
            Clients.All.clear();
        }
    }
}