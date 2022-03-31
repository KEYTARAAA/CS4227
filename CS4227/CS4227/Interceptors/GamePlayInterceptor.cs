using System;
using System.Collections.Generic;
using System.Text;
using CS4227.ContextObjects;
using CS4227.DataBase;


namespace CS4227.Interceptors
{
    class GamePlayInterceptor : Interceptor
    {
        GamePlayObject contextObject;

        public GamePlayInterceptor(GamePlayObject contextObject)
        {
            this.contextObject = contextObject;
        }

        public void event_callback()
        {
            DB db = new DB();
            db.createStatsFile(contextObject.getPlayerName() + "_total_stats");
            db.createGameLogsFile(contextObject.getPlayerName() + "_game_logs");

            string[] totalStats = db.readTotalStats(contextObject.getPlayerName());
            int[] myInts = Array.ConvertAll(totalStats, s => int.Parse(s));
            if (contextObject.getCommand() == "Attack") {
                myInts[0] += 1;
            }

            if (contextObject.getCommand() == "MoveUp" || contextObject.getCommand() == "MoveDown" 
                || contextObject.getCommand() == "MoveLeft" || contextObject.getCommand() == "MoveRight")
            {
                myInts[4] += 1;
            }

            string[] result = Array.ConvertAll(myInts, x => x.ToString());
            db.writeToStatsFile(contextObject.getPlayerName() + "_total_stats", result);
            db.writeToGameLogsFile(contextObject.getPlayerName() + "_game_logs", contextObject.getFull());

        }
    }
}