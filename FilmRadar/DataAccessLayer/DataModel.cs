using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class DataModel
    {
        SqlConnection con; SqlCommand cmd;

        public DataModel()
        {
            con = new SqlConnection(ConnectionString.ConStr);
            cmd = con.CreateCommand();
        }
        #region Categories Method
        public List<Categories> CategoryList()
        {
            List<Categories> categories = new List<Categories>();
            try
            {
                cmd.CommandText = "SELECT ID,Name,Status FROM Categories";
                cmd.Parameters.Clear();
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Categories cat = new Categories();
                    cat.ID = reader.GetInt32(0);
                    cat.Name = reader.GetString(1);
                    cat.Status = reader.GetBoolean(2);
                    cat.StatusStr = reader.GetBoolean(2) ? "<label style='color:green'>Aktif</label>" : "<label style='color:red'>Pasif</label>";
                    categories.Add(cat);
                }
                return categories;
            }
            catch 
            {
                return null;                
            }
            finally
            {
                con.Close();
            }
        }
        public List<Categories> CategoryList(bool staus)
        {
            List<Categories> categories = new List<Categories>();
            try
            {
                cmd.CommandText = "SELECT ID,Name,Status FROM Categories WHERE Status=@status";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@status", staus);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Categories cat = new Categories();
                    cat.ID = reader.GetInt32(0);
                    cat.Name = reader.GetString(1);
                    cat.Status = reader.GetBoolean(2);
                    cat.StatusStr = reader.GetBoolean(2) ? "<label style='color:green'>Aktif</label>" : "<label style='color:red'>Pasif</label>";
                    categories.Add(cat);
                }
                return categories;
            }
            catch
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }
        public Categories GetCategory(int id)
        {
            try
            {
                Categories cat = new Categories();
                cmd.CommandText = "SELECT ID,Name,Status FROM Categories WHERE ID=@id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    cat.ID = reader.GetInt32(0);
                    cat.Name = reader.GetString(1);
                    cat.Status = reader.GetBoolean(2);
                    cat.StatusStr = reader.GetBoolean(2) ? "<label style='color:green'>Aktif</label>" : "<label style='color:red'>Pasif</label>";
                }
                return cat;
            }
            catch 
            {
                return null;                
            }
            finally
            {
                con.Close();
            }
        }
        public void CategoryStatusChange(int id)
        {
            try
            {
                Categories cat = GetCategory(id);
                if (cat.Status)
                {
                    cmd.CommandText = "UPDATE Categories SET Status=0 WHERE ID=@id";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@id", id);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
                else
                {
                    cmd.CommandText = "UPDATE Categories SET Status=1 WHERE ID=@id";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@id", id);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            finally
            {
                con.Close();                
            }
        }
        public bool CategoryAdd(Categories cat)
        {
            try
            {
                cmd.CommandText = "INSERT INTO Categories (Name,Status) VALUES (@name,@status)";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@name", cat.Name);
                cmd.Parameters.AddWithValue("@status", cat.Status);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch 
            {
                return false;
            }
            finally
            {
                con.Close();
            }
        }
        public bool CategoryEdit(Categories cat)
        {
            try
            {
                cmd.CommandText = "UPDATE Categories SET Name=@name, Status=@status WHERE ID=@id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", cat.ID);
                cmd.Parameters.AddWithValue("@name", cat.Name);
                cmd.Parameters.AddWithValue("@status", cat.Status);
                con.Open();
                cmd.ExecuteNonQuery();

                return true;
            }
            catch 
            {
                return false;
            }
            finally
            {
                con.Close();
            }
        }
        #endregion
        #region Assistant
        public bool DataControl(string table, string column, string data)
        {
            try
            {
                cmd.CommandText = "SELECT COUNT (*) FROM " + table + " WHERE " + column + " =@name";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@name", data);
                con.Open();
                int count = Convert.ToInt32(cmd.ExecuteScalar());
                if (count == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            finally
            {
                con.Close();
            }

        }
        #endregion
        #region UserType & Users Method
        public List<UserType> UserTypeList()
        {
            List<UserType> userType = new List<UserType>();
            try
            {
                cmd.CommandText = "SELECT ID,Name,Status FROM UserType";
                cmd.Parameters.Clear();
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    UserType usertype = new UserType();
                    usertype.ID = reader.GetInt32(0);
                    usertype.Name = reader.GetString(1);
                    usertype.Status = reader.GetBoolean(2);
                    usertype.StatusStr = reader.GetBoolean(2) ? "<label style='color:green'>Aktif</label>" : "<label style='color:red'>Pasif</label>";
                    userType.Add(usertype);
                }
                return userType;
            }
            catch
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }
        public UserType GetUserType(int id)
        {
            try
            {
                UserType userType = new UserType();
                cmd.CommandText = "SELECT ID,Name,Status FROM UserType WHERE ID=@id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    userType.ID = reader.GetInt32(0);
                    userType.Name = reader.GetString(1);
                    userType.Status = reader.GetBoolean(2);
                    userType.StatusStr = reader.GetBoolean(2) ? "<label style='color:green'>Aktif</label>" : "<label style='color:red'>Pasif</label>";
                }
                return userType;
            }
            catch
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }
        public void UserTypeStatusChange(int id)
        {
            try
            {
                UserType userType = GetUserType(id);
                if (userType.Status)
                {
                    cmd.CommandText = "UPDATE UserType SET Status=0 WHERE ID=@id";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@id", id);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
                else
                {
                    cmd.CommandText = "UPDATE UserType SET Status=1 WHERE ID=@id";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@id", id);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            finally
            {
                con.Close();
            }
        }
        public bool UserTypeAdd(UserType userType)
        {
            try
            {
                cmd.CommandText = "INSERT INTO UserType (Name,Status) VALUES (@name,@status)";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@name", userType.Name);
                cmd.Parameters.AddWithValue("@status", userType.Status);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                con.Close();
            }
        }
        public bool UserTypeEdit(UserType userType)
        {
            try
            {
                cmd.CommandText = "UPDATE UserType SET Name=@name, Status=@status WHERE ID=@id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", userType.ID);
                cmd.Parameters.AddWithValue("@name", userType.Name);
                cmd.Parameters.AddWithValue("@status", userType.Status);
                con.Open();
                cmd.ExecuteNonQuery();

                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                con.Close();
            }
        }
        public List<Users> UsersList()
        {
            List<Users> users = new List<Users>();
            try
            {
                cmd.CommandText = "SELECT Us.ID,Us.Name,Us.Surname,Us.FavoriteFilm,Us.Occupation,Us.UserType_ID,Ustyp.Name,Us.Username,Us.DateTime,Us.Status FROM Users AS US JOIN UserType AS Ustyp ON Us.UserType_ID=Ustyp.ID";
                cmd.Parameters.Clear();
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Users us = new Users();
                    us.ID = reader.GetInt32(0);
                    us.Name = reader.GetString(1);
                    us.Surname = reader.GetString(2);
                    us.FavoriteFilm = reader.GetString(3);
                    us.Occupation = reader.GetString(4);
                    us.UserType_ID = reader.GetInt32(5);
                    us.UserTypeStr = reader.GetString(6);
                    us.Username = reader.GetString(7);
                    us.DateTime = reader.GetDateTime(8);
                    us.Status = reader.GetBoolean(9);
                    us.StatusStr = reader.GetBoolean(9) ? "<label style='color:green'>Aktif</label>" : "<label style='color:red'>Pasif</label>";
                    users.Add(us);
                }
                return users;
            }
            catch
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }
        public Users GetUser(int id)
        {
            try
            {
                Users us = new Users();
                cmd.CommandText = "SELECT Us.ID,Us.Name,Us.Surname,Us.FavoriteFilm,Us.Occupation,Us.UserType_ID,Ustyp.Name,Us.Username,Us.DateTime,Us.Status FROM Users AS US JOIN UserType AS Ustyp ON Us.UserType_ID=Ustyp.ID WHERE Us.ID=@id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    us.ID = reader.GetInt32(0);
                    us.Name = reader.GetString(1);
                    us.Surname = reader.GetString(2);
                    us.FavoriteFilm = reader.GetString(3);
                    us.Occupation = reader.GetString(4);
                    us.UserType_ID = reader.GetInt32(5);
                    us.UserTypeStr = reader.GetString(6);
                    us.Username = reader.GetString(7);
                    us.DateTime = reader.GetDateTime(8);
                    us.Status = reader.GetBoolean(9);
                    us.StatusStr = reader.GetBoolean(9) ? "<label style='color:green'>Aktif</label>" : "<label style='color:red'>Pasif</label>";
                }
                return us;
            }
            catch
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }        
        public void UserStatusChange(int id)
        {
            try
            {
                Users user = GetUser(id);
                if (user.Status)
                {
                    cmd.CommandText = "UPDATE Users SET Status=0 WHERE ID=@id";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@id", id);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
                else
                {
                    cmd.CommandText = "UPDATE Users SET Status=1 WHERE ID=@id";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@id", id);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            finally
            {
                con.Close();
            }
        }
        public bool UserAdd(Users us)
        {
            try
            {
                cmd.CommandText = "INSERT INTO Users (Name,Surname,FavoriteFilm,Occupation,UserType_ID,Username,DateTime,Status,Password) VALUES (@name,@surname,@fav,@occupation,@usertypeID,@username,@datetime,@status,@password)";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@name", us.Name);
                cmd.Parameters.AddWithValue("@surname", us.Surname);
                cmd.Parameters.AddWithValue("@fav", us.FavoriteFilm);
                cmd.Parameters.AddWithValue("@occupation", us.Occupation);
                cmd.Parameters.AddWithValue("@usertypeID", us.UserType_ID);
                cmd.Parameters.AddWithValue("@username", us.Username);
                cmd.Parameters.AddWithValue("@datetime", us.DateTime);
                cmd.Parameters.AddWithValue("@status", us.Status);
                cmd.Parameters.AddWithValue("@password", us.Password);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch 
            {
                return false;
            }
            finally
            {
                con.Close();
            }
        }
        public bool UserEdit(Users user)
        {
            try
            {
                cmd.CommandText = "UPDATE Users SET Name=@name, Surname=@surname, FavoriteFilm=@fav, Occupation=@occupation, UserType_ID=@usertypeID, Username=@username, Status=@status WHERE ID=@id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", user.ID);
                cmd.Parameters.AddWithValue("@name", user.Name);
                cmd.Parameters.AddWithValue("@surname", user.Surname);
                cmd.Parameters.AddWithValue("@fav", user.FavoriteFilm);
                cmd.Parameters.AddWithValue("@occupation", user.Occupation);
                cmd.Parameters.AddWithValue("@usertypeID", user.UserType_ID);
                cmd.Parameters.AddWithValue("@username", user.Username);
                cmd.Parameters.AddWithValue("@status", user.Status);
                con.Open();
                cmd.ExecuteNonQuery();

                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                con.Close();
            }
        }
        #endregion
        #region Films Method
        public List<Films> FilmsList()
        {
            List<Films> films = new List<Films>();
            try
            {
                cmd.CommandText = "SELECT F.ID,F.FilmName,F.IMDB,F.Category_ID,Cat.Name,F.Photo,F.Summary,F.Topic,F.Status FROM Films AS F JOIN Categories AS Cat ON F.Category_ID=Cat.ID";
                cmd.Parameters.Clear();
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Films f = new Films();
                    f.ID = reader.GetInt32(0);
                    f.FilmName = reader.GetString(1);
                    f.IMDB = reader.GetDecimal(2);
                    f.Category_ID = reader.GetInt32(3);
                    f.CategoryStr = reader.GetString(4);
                    f.Photo = reader.GetString(5);
                    f.Summary = reader.GetString(6);
                    f.Topic = reader.GetString(7);
                    f.Status = reader.GetBoolean(8);
                    f.StatusStr = reader.GetBoolean(8) ? "<label style='color:green'>Aktif</label>" : "<label style='color:red'>Pasif</label>";
                    films.Add(f);
                }
                return films;
            }
            catch
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }
        public List<Films> FilmsList(bool status)
        {
            List<Films> films = new List<Films>();
            try
            {
                cmd.CommandText = "SELECT F.ID,F.FilmName,F.IMDB,F.Category_ID,Cat.Name,F.Photo,F.Summary,F.Topic,F.Status FROM Films AS F JOIN Categories AS Cat ON F.Category_ID=Cat.ID WHERE F.Status=@status";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@status", status);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Films f = new Films();
                    f.ID = reader.GetInt32(0);
                    f.FilmName = reader.GetString(1);
                    f.IMDB = reader.GetDecimal(2);
                    f.Category_ID = reader.GetInt32(3);
                    f.CategoryStr = reader.GetString(4);
                    f.Photo = reader.GetString(5);
                    f.Summary = reader.GetString(6);
                    f.Topic = reader.GetString(7);
                    f.Status = reader.GetBoolean(8);
                    f.StatusStr = reader.GetBoolean(8) ? "<label style='color:green'>Aktif</label>" : "<label style='color:red'>Pasif</label>";
                    films.Add(f);
                }
                return films;
            }
            catch
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }
        public List<Films> FilmsList(int catID)
        {
            List<Films> films = new List<Films>();
            try
            {
                cmd.CommandText = "SELECT F.ID,F.FilmName,F.IMDB,F.Category_ID,Cat.Name,F.Photo,F.Summary,F.Topic,F.Status FROM Films AS F JOIN Categories AS Cat ON F.Category_ID=Cat.ID WHERE F.Status=1 AND F.Category_ID=@catID";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@catID", catID);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Films f = new Films();
                    f.ID = reader.GetInt32(0);
                    f.FilmName = reader.GetString(1);
                    f.IMDB = reader.GetDecimal(2);
                    f.Category_ID = reader.GetInt32(3);
                    f.CategoryStr = reader.GetString(4);
                    f.Photo = reader.GetString(5);
                    f.Summary = reader.GetString(6);
                    f.Topic = reader.GetString(7);
                    f.Status = reader.GetBoolean(8);
                    f.StatusStr = reader.GetBoolean(8) ? "<label style='color:green'>Aktif</label>" : "<label style='color:red'>Pasif</label>";
                    films.Add(f);
                }
                return films;
            }
            catch
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }
        public Films GetFilm(int id)
        {
            try
            {
                Films f = new Films();
                cmd.CommandText = "SELECT F.ID,F.FilmName,F.IMDB,F.Category_ID,Cat.Name,F.Photo,F.Summary,F.Topic,F.Status FROM Films AS F JOIN Categories AS Cat ON F.Category_ID=Cat.ID WHERE F.ID=@id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    f.ID = reader.GetInt32(0);
                    f.FilmName = reader.GetString(1);
                    f.IMDB = reader.GetDecimal(2);
                    f.Category_ID = reader.GetInt32(3);
                    f.CategoryStr = reader.GetString(4);
                    f.Photo = reader.GetString(5);
                    f.Summary = reader.GetString(6);
                    f.Topic = reader.GetString(7);
                    f.Status = reader.GetBoolean(8);
                    f.StatusStr = reader.GetBoolean(8) ? "<label style='color:green'>Aktif</label>" : "<label style='color:red'>Pasif</label>";

                }
                return f;
            }
            catch
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }
        public void FilmStatusChange(int id)
        {
            try
            {
                Films film = GetFilm(id);
                if (film.Status)
                {
                    cmd.CommandText = "UPDATE Films SET Status=0 WHERE ID=@id";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@id", id);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
                else
                {
                    cmd.CommandText = "UPDATE Films SET Status=1 WHERE ID=@id";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@id", id);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            finally
            {
                con.Close();
            }
        }
        public bool FilmAdd(Films film)
        {
            try
            {
                cmd.CommandText = "INSERT INTO Films (FilmName,IMDB,Category_ID,Photo,Summary,Topic,Status) VALUES (@filmName,@iMDB,@category_ID,@photo,@summary,@topic,@status)";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("filmName", film.FilmName);
                cmd.Parameters.AddWithValue("iMDB", film.IMDB);
                cmd.Parameters.AddWithValue("category_ID", film.Category_ID);
                cmd.Parameters.AddWithValue("photo", film.Photo);
                cmd.Parameters.AddWithValue("summary", film.Summary);
                cmd.Parameters.AddWithValue("topic", film.Topic);
                cmd.Parameters.AddWithValue("status", film.Status);
                con.Open();
                cmd.ExecuteNonQuery();

                return true;
            }
            catch 
            {
                return false;
            }
            finally
            {
                con.Close();
            }
        }
        public bool FilmEdit(Films film)
        {
            try
            {
                cmd.CommandText = "UPDATE Films SET FilmName=@filmname, IMDB=@imdb, Category_ID=@categoryID, Photo=@photo, Summary=@summary, Topic=@topic, Status=@status WHERE ID=@id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", film.ID);
                cmd.Parameters.AddWithValue("@filmname", film.FilmName);
                cmd.Parameters.AddWithValue("@imdb", film.IMDB);
                cmd.Parameters.AddWithValue("@categoryID", film.Category_ID);
                cmd.Parameters.AddWithValue("@photo", film.Photo);
                cmd.Parameters.AddWithValue("@summary", film.Summary);
                cmd.Parameters.AddWithValue("@topic", film.Topic);
                cmd.Parameters.AddWithValue("@status", film.Status);
                con.Open();
                cmd.ExecuteNonQuery();

                return true;
            }
            catch 
            {
                return false;
            }
            finally
            {
                con.Close();
            }
        }
        #endregion
        #region Comment Methods
        public List<Comments> AllCommentsList()
        {
            try
            {
                List<Comments> comments = new List<Comments>();
                cmd.CommandText = "SELECT C.ID, C.Name, C.Topic, C.Users_ID, Us.Name, C.Films_ID, F.FilmName, C.CommentTime, C.Viewcomment, C.Status FROM Comments AS C JOIN Users AS Us ON C.Users_ID=Us.ID JOIN Films AS F ON C.Films_ID=F.ID";
                cmd.Parameters.Clear();
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Comments comment = new Comments();
                    comment.ID = reader.GetInt32(0);
                    comment.Name = reader.GetString(1);
                    comment.Topic = reader.GetString(2);
                    comment.User_ID = reader.GetInt32(3);
                    comment.UserStr = reader.GetString(4);
                    comment.Films_ID = reader.GetInt32(5);
                    comment.FilmsStr = reader.GetString(6);
                    comment.CommentTime = reader.GetDateTime(7);
                    comment.Viewcomment = reader.GetInt32(8);
                    comment.Status = reader.GetBoolean(9);
                    comment.StatusStr = reader.GetBoolean(9) ? "<label style='color:green'>Aktif</label>" : "<label style='color:red'>Pasif</label>";
                    comments.Add(comment);
                }
                return comments;
            }
            catch 
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }
        public List<Comments> ActiveCommentsList()
        {
            try
            {
                List<Comments> comments = new List<Comments>();
                cmd.CommandText = "SELECT C.ID, C.Name, C.Topic, C.Users_ID, Us.Name, C.Films_ID, F.FilmName, C.CommentTime, C.Viewcomment, C.Status FROM Comments AS C JOIN Users AS Us ON C.Users_ID=Us.ID JOIN Films AS F ON C.Films_ID=F.ID WHERE C.Status=1";
                cmd.Parameters.Clear();
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Comments comment = new Comments();
                    comment.ID = reader.GetInt32(0);
                    comment.Name = reader.GetString(1);
                    comment.Topic = reader.GetString(2);
                    comment.User_ID = reader.GetInt32(3);
                    comment.UserStr = reader.GetString(4);
                    comment.Films_ID = reader.GetInt32(5);
                    comment.FilmsStr = reader.GetString(6);
                    comment.CommentTime = reader.GetDateTime(7);
                    comment.Viewcomment = reader.GetInt32(8);
                    comment.Status = reader.GetBoolean(9);
                    comment.StatusStr = reader.GetBoolean(9) ? "<label style='color:green'>Aktif</label>" : "<label style='color:red'>Pasif</label>";
                    comments.Add(comment);
                }
                return comments;
            }
            catch
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }
        public List<Comments> ActiveCommentsList(int id)
        {
            try
            {
                List<Comments> comments = new List<Comments>();
                cmd.CommandText = "SELECT C.ID, C.Name, C.Topic, C.Users_ID, Us.Name, C.Films_ID, F.FilmName, C.CommentTime, C.Viewcomment, C.Status FROM Comments AS C JOIN Users AS Us ON C.Users_ID=Us.ID JOIN Films AS F ON C.Films_ID=F.ID WHERE C.Status=1 AND C.Films_ID=@id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("id", id);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Comments comment = new Comments();
                    comment.ID = reader.GetInt32(0);
                    comment.Name = reader.GetString(1);
                    comment.Topic = reader.GetString(2);
                    comment.User_ID = reader.GetInt32(3);
                    comment.UserStr = reader.GetString(4);
                    comment.Films_ID = reader.GetInt32(5);
                    comment.FilmsStr = reader.GetString(6);
                    comment.CommentTime = reader.GetDateTime(7);
                    comment.Viewcomment = reader.GetInt32(8);
                    comment.Status = reader.GetBoolean(9);
                    comment.StatusStr = reader.GetBoolean(9) ? "<label style='color:green'>Aktif</label>" : "<label style='color:red'>Pasif</label>";
                    comments.Add(comment);
                }
                return comments;
            }
            catch
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }
        public List<Comments> PassiveCommentsList()
        {
            try
            {
                List<Comments> comments = new List<Comments>();
                cmd.CommandText = "SELECT C.ID, C.Name, C.Topic, C.Users_ID, Us.Name, C.Films_ID, F.FilmName, C.CommentTime, C.Viewcomment, C.Status FROM Comments AS C JOIN Users AS Us ON C.Users_ID=Us.ID JOIN Films AS F ON C.Films_ID=F.ID WHERE C.Status=0";
                cmd.Parameters.Clear();
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Comments comment = new Comments();
                    comment.ID = reader.GetInt32(0);
                    comment.Name = reader.GetString(1);
                    comment.Topic = reader.GetString(2);
                    comment.User_ID = reader.GetInt32(3);
                    comment.UserStr = reader.GetString(4);
                    comment.Films_ID = reader.GetInt32(5);
                    comment.FilmsStr = reader.GetString(6);
                    comment.CommentTime = reader.GetDateTime(7);
                    comment.Viewcomment = reader.GetInt32(8);
                    comment.Status = reader.GetBoolean(9);
                    comment.StatusStr = reader.GetBoolean(9) ? "<label style='color:green'>Aktif</label>" : "<label style='color:red'>Pasif</label>";
                    comments.Add(comment);
                }
                return comments;
            }
            catch
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }
        public Comments GetComments(int id)
        {
            try
            {
                List<Comments> comments = new List<Comments>();
                cmd.CommandText = "SELECT C.ID, C.Name, C.Topic, C.Users_ID, Us.Name, C.Films_ID, F.FilmName, C.CommentTime, C.Viewcomment, C.Status FROM Comments AS C JOIN Users AS Us ON C.Users_ID=Us.ID JOIN Films AS F ON C.Films_ID=F.ID WHERE C.ID=@id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                Comments comment = new Comments();
                while (reader.Read())
                {
                    comment.ID = reader.GetInt32(0);
                    comment.Name = reader.GetString(1);
                    comment.Topic = reader.GetString(2);
                    comment.User_ID = reader.GetInt32(3);
                    comment.UserStr = reader.GetString(4);
                    comment.Films_ID = reader.GetInt32(5);
                    comment.FilmsStr = reader.GetString(6);
                    comment.CommentTime = reader.GetDateTime(7);
                    comment.Viewcomment = reader.GetInt32(8);
                    comment.Status = reader.GetBoolean(9);
                    comment.StatusStr = reader.GetBoolean(9) ? "<label style='color:green'>Aktif</label>" : "<label style='color:red'>Pasif</label>";
                    comments.Add(comment);
                }
                return comment;
            }
            catch
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }
        public void CommentStatusChange(int id)
        {
            try
            {
                Comments comment = GetComments(id);
                if (comment.Status)
                {
                    cmd.CommandText = "UPDATE Comments SET Status=0 WHERE ID=@id";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@id", id);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
                else
                {
                    cmd.CommandText = "UPDATE Comments SET Status=1 WHERE ID=@id";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@id", id);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            finally
            {
                con.Close();
            }
        }
        public bool PostComment(Comments c)
        {
            try
            {
                cmd.CommandText = "INSERT INTO Comments (Name,Topic,Users_ID,Films_ID,CommentTime,Viewcomment,Status) VALUES (@name,@topic,@userid,@filmid,@commentTime,@viewcomment,@status)";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@name", c.Name);
                cmd.Parameters.AddWithValue("@topic", c.Topic);
                cmd.Parameters.AddWithValue("@userid", c.User_ID);
                cmd.Parameters.AddWithValue("@filmid", c.Films_ID);
                cmd.Parameters.AddWithValue("@commentTime", c.CommentTime);
                cmd.Parameters.AddWithValue("@viewcomment", c.Viewcomment);
                cmd.Parameters.AddWithValue("@status", c.Status);
                con.Open();
                cmd.ExecuteNonQuery();

                return true;
            }
            catch 
            {
                return false;                  
            }
            finally
            {
                con.Close();
            }
        }
        #endregion
        #region User Login & Register
        public Users UserLogin(string username, string password)
        {
            try
            {
                cmd.CommandText = "SELECT COUNT(*) FROM Users WHERE Username=@username AND Password=@password";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", password);
                con.Open();
                int count = Convert.ToInt32(cmd.ExecuteScalar());
                if (count>0)
                {
                    cmd.CommandText = "SELECT Us.ID, Us.Name, Us.Surname, Us.FavoriteFilm, Us.Occupation, Us.UserType_ID, Ustyp.Name, Us.Username, Us.Status FROM Users AS Us JOIN UserType AS Ustyp ON Us.UserType_ID=Ustyp.ID";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@password", password);
                    SqlDataReader reader = cmd.ExecuteReader();
                    Users user = new Users();
                    while (reader.Read())
                    {
                        user.ID = reader.GetInt32(0);
                        user.Name = reader.GetString(1);
                        user.Surname = reader.GetString(2);
                        user.FavoriteFilm = reader.GetString(3);
                        user.Occupation = reader.GetString(4);
                        user.UserType_ID = reader.GetInt32(5);
                        user.UserTypeStr = reader.GetString(6);
                        user.Username = reader.GetString(7);
                        user.Status = reader.GetBoolean(8);
                        user.StatusStr = reader.GetBoolean(8) ? "<label style='color:green'>Aktif</label>" : "<label style='color:red'>Pasif</label>";
                    }
                    return user;
                }
                else
                {
                    return null;
                }
            }
            catch 
            {
                return null;
            }
            finally
            {
                con.Close();
            }

        }
        public bool Register(Users us)
        {
            try
            {
                cmd.CommandText = "INSERT INTO Users (Name,Surname,FavoriteFilm,Occupation,UserType_ID,Username,DateTime,Status,Password) VALUES (@name,@surname,@favoritefilm,@occupation,3,@username,@datetime,1,@password)";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@name", us.Name);
                cmd.Parameters.AddWithValue("@surname", us.Surname);
                cmd.Parameters.AddWithValue("@favoritefilm", us.FavoriteFilm);
                cmd.Parameters.AddWithValue("@occupation", us.Occupation);
                cmd.Parameters.AddWithValue("@username", us.Username);
                cmd.Parameters.AddWithValue("@datetime", us.DateTime);
                cmd.Parameters.AddWithValue("@password", us.Password);
                con.Open();
                cmd.ExecuteNonQuery();

                return true;
            }
            catch 
            {
                return false;
            }
            finally
            {
                con.Close();
            }
        }
        public Users CheckAuthorization(string username, string password)
        {
            try
            {
                cmd.CommandText = "SELECT COUNT(*) FROM Users WHERE Username=@username AND Password=@password";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", password);
                con.Open();
                int count = Convert.ToInt32(cmd.ExecuteScalar());
                if (count>0)
                {
                    cmd.CommandText = "SELECT Us.ID,Us.Name,Us.Surname,Us.FavoriteFilm,Us.Occupation,Us.UserType_ID,Ustyp.Name,Us.Username,Us.DateTime,Us.Status FROM Users AS US JOIN UserType AS Ustyp ON Us.UserType_ID=Ustyp.ID WHERE Username=@username AND Password=@password";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@password", password);
                    SqlDataReader reader = cmd.ExecuteReader();
                    Users user = new Users();
                    while (reader.Read())
                    {
                        user.ID = reader.GetInt32(0);
                        user.Name = reader.GetString(1);
                        user.Surname = reader.GetString(2);
                        user.FavoriteFilm = reader.GetString(3);
                        user.Occupation = reader.GetString(4);
                        user.UserType_ID = reader.GetInt32(5);
                        user.UserTypeStr = reader.GetString(6);
                        user.Username = reader.GetString(7);
                        user.DateTime = reader.GetDateTime(8);
                        user.Status = reader.GetBoolean(9);
                        user.StatusStr = reader.GetBoolean(9) ? "<label style='color:green'>Aktif</label>" : "<label style='color:red'>Pasif</label>";
                    }
                    return user;
                }
                else
                {
                    return null;
                }
            }
            catch 
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }
        #endregion

    }
}
