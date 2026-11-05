//using Android.App;
using dGomezS5.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace dGomezS5.Repositories
{
    
    public class PersonRepository
    {
        string _dbPath; //Ruta
        private SQLiteConnection _conn;
        public string? Message { get; set; }
        public void Init()
        {
            if (_conn is not null)
                return;
            _conn = new(_dbPath);
            _conn.CreateTable<Persona>();
        }
        public PersonRepository(string path) 
        {
            _dbPath = path;
        }
        public void AddNewPerson(string name) 
        {
            int result = 0;
            try
            {
                Init();
                if (string.IsNullOrEmpty(name))
                    throw new Exception("El nombre es requerido");
                Persona persona = new() { Name = name};
                result = _conn.Insert(persona);
            }
            catch (Exception ex)
            {

                Message = string.Format("ERROR" + ex.Message);
            }
        }
        public List<Persona> GetAllPerson() 
        {
            try
            {
                Init();
                return _conn.Table<Persona>().ToList();
            }
            catch (Exception ex)
            {

                Message = string.Format("ERROR" + ex.Message);
            }
            return new List<Persona>();

        }
        public void DeletePerson(int id)
        {
            try
            {
                Init();
                _conn.Delete<Persona>(id);
                Message = "Persona eliminada correctamente";
            }
            catch (Exception ex)
            {
                Message = "ERROR: " + ex.Message;
            }
        }
    }
}
