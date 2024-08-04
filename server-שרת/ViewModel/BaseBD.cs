using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Model;

namespace ViewModel
{
    public abstract class BaseDB
    {
        //מחרוזת הקישור -מכיל - 1. הספק שאיתו משתמשים,  2. ניתוב מלא למיקום המסד נתונים  
        protected string ConnectionString;
        //אוביקט של התחברות - יכיל בתוכו את המחרוזת כחלק מהמאפיינים
        protected OleDbConnection Connection;
        //  connection//הפקודה  -אותה נשלח להרצה - יכיל בתוכו את אוביקט הקישור    
        protected OleDbCommand Command;
        //אוביקט שלתוכו יכנס מה שחוזר מהרצת הפקודה- חוזר אוביקטים של SQL
        protected OleDbDataReader reader;
        //לתוך הליסט יכנס מה שחוזר מהרידר אבל אחרי המרה לאוביקטים שלנו
        protected List<BaseEntity> list;


        protected List<BaseEntity> inserted = new List<BaseEntity>();
        protected List<BaseEntity> changed = new List<BaseEntity>();
        protected List<BaseEntity> deleted = new List<BaseEntity>();

        public BaseDB(string ClassName)
        {
            //איתחול אוביקט הקישור עם המחרוזת
            Connection = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + GetCurrentPath() + "Data\\תמר הולצר.accdb");
            //איתחול הפקודה
            Command = new OleDbCommand();
            //לתוך מאפייני הפקודה נציב את הקישור, ואז בשליחת הפקודה - אוטומטי יודע לאן ללכת
            Command.Connection = Connection;
            //  מה אני רוצה שיקרה -שלוף את השם המלא מטבלת תלמידות או הוסף אוביקט חדש לטבלת הזמנות
            Command.CommandText = "select * from " + ClassName;
            list = new List<BaseEntity>();
        }

        //הפונקציה שתמיר את האוביקטים אחד לאחד sql to c#
        //לכל טבלה בנפרד יש את המימוש לפי המאפיינים שלו - אבל כאן מכריחים את כולם שתהיה כזו פונקציה
        protected abstract BaseEntity CreateModel();
        public string GetCurrentPath()
        {
            string path = System.IO.Directory.GetCurrentDirectory();
            string[] arr = path.Split('\\');
            path = "";
            for (int i = 0; i < arr.Length - 3; i++)
            {
                path += arr[i] + "\\";
            }
            return path;
        }
        //פונקציה של השליפה - זהה לכל הקלאסים 
        protected void Select()
        {
            try
            {
                //פותח את החיבור למסד - לאקסס
                Connection.Open();
                //האוביקט מקבל  לתוכו את מה שחוזר מהרצת הפקודה
                reader = Command.ExecuteReader();

                //כל עוד יש שורות שניתן לעבור עליהם
                while (reader.Read())
                {
                    // לC# SQLשולחת להמרה את השורה הנוכחית - המרה מ   
                    //ומוסיפה את האוביקט לאחר ההמרה- לליסט
                    list.Add(CreateModel());
                }

            }
            catch (Exception ex)
            {

            }
            finally
            {
                //סגירת החיבור למסד
                if (Connection.State == System.Data.ConnectionState.Open)
                    Connection.Close();
            }
        }
        public void Add(BaseEntity item)
        {
            if (item != null)
            {
                list.Add(item);
                inserted.Add(item);
            }
        }
        public void Update(BaseEntity item)
        {
            if (item != null)
            {
                changed.Add(item);
                list.Remove(list.FirstOrDefault(x => x.Equals(item)));
                list.Add(item);
            }
        }

        public void Deleted(BaseEntity item)
        {
            if (item != null)
            {
                deleted.Add(item);
                list.Remove(list.FirstOrDefault(x => x.Equals(item)));
            }
        }

        public int SaveChanges()
        {
            int records = 0;
            try
            {
                Command.Connection = Connection;
                Connection.Open();
                foreach (var item in inserted)
                {
                    try
                    {
                        Command.CommandText = SQLBuilder.InsertSQL(item);
                        records += Command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {

                    }
                }
                inserted.Clear();
                foreach (var item in changed)
                {
                    try
                    {
                        Command.CommandText = SQLBuilder.UpdateSQL(item);
                        records += Command.ExecuteNonQuery();
                    }
                    catch
                    {

                    }

                }
                changed.Clear();
                foreach (var item in deleted)
                {
                    try
                    {
                        Command.CommandText = SQLBuilder.DeleteSQL(item);
                        records += Command.ExecuteNonQuery();
                        list.Remove(item);
                    }
                    finally { }
                }
                deleted.Clear();
            }

            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message + "\nDataBase:" + Command.CommandText);
            }
            finally
            {
                if (Connection.State == System.Data.ConnectionState.Open)
                    Connection.Close();
            }

            return records;
        }
        protected abstract string CreateInsertCommand(BaseEntity item);
        protected abstract string CreateUpdateCommand(BaseEntity item);
        protected abstract string CreateDeletedCommand(BaseEntity item);
    }
}


