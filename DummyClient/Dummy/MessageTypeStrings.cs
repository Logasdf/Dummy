using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dummy
{
    public static class MessageTypeStrings
    {
        public const string DATA = "Data";
        public const string INT32 = "Int32";
        public const string CONTENT_TYPE = "contentType";
        public const string USERNAME = "userName";

        //LOBBY
        public const string ASSIGN_USERNAME = "ASSIGN_USERNAME";
        public const string ROOMLIST = "RoomList";
        public const string ROOMINFO = "RoomInfo";
        public const string ERRORMESSAGE = "errorMessage";

        public const string CREATE_ROOM = "CREATE_ROOM";
        public const string ENTER_ROOM = "ENTER_ROOM";
        public const string REJECT_CREATEROOM = "REJECT_CREATE_ROOM";
        public const string REJECT_ENTERROOM = "REJECT_ENTER_ROOM";

        public const string ROOMNAME = "roomName";
        public const string LIMIT = "limits";

        //WAITING ROOM
        public const string MY_POSITION = "CLIENT_POSITION";
        public const string CHAT_MESSAGE = "CHAT_MESSAGE";
        public const string START_GAME = "START_GAME";
        public const string REJECT_START_GAME = "REJECT_START_GAME";

        public const string CLIENT = "Client";
        public const string ROOMID = "roomId";
        public const string POSITION = "position";
        public const string TOREADY = "toReady";
        public const string PREV_POSITION = "prev_position";
        public const string NEXT_POSITION = "next_position";
        public const string CHAT_STRING = "message";
        public const string NEWHOST = "newHost";

        //InGame
        public const string FIRE_BULLET = "FIRE_BULLET";
        public const string BE_SHOT = "BE_SHOT";

        public const string PLAYSTATE = "PlayState";
        public const string WORLDSTATE = "WorldState";
        public const string MESSAGEFROM = "fromClnt";
        public const string MESSAGETO = "toClnt";

    }
}
