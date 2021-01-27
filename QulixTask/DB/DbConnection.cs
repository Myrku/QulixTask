using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using QulixTask.Models;

namespace QulixTask.DB
{
    public class DbConnection
    {
        //Строка подключение к БД
        private const string CONNECTION_STRING = "Data Source=DESKTOP-J2HVNN0;Initial Catalog=QulixTask;Integrated Security=True";

        //Получение списка всех компаний
        async public Task<List<Company>> GetAllCompanies()
        {
            List<Company> companies = new List<Company>();
            using(SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                SqlCommand command = new SqlCommand("Select * From Сompanies", connection);
                await connection.OpenAsync();
                SqlDataReader dataReader = await command.ExecuteReaderAsync();
                while(await dataReader.ReadAsync())
                {
                    Company company = new Company();
                    company.id = Convert.ToInt32(dataReader["id"]);
                    company.companyName = dataReader["companyName"].ToString();
                    company.companyForm = dataReader["companyForm"].ToString();
                    companies.Add(company);
                }
                await connection.CloseAsync();
            }
            return companies;
        }

        //Добавление новой компании
        async public void AddCompany(Company company)
        {
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                SqlCommand command = new SqlCommand("Insert Into Сompanies(companyName, companyForm) Values(@companyName, @companyForm)", connection);
                await connection.OpenAsync();

                SqlParameter companyNameParam = new SqlParameter("@companyName", company.companyName);
                command.Parameters.Add(companyNameParam);

                SqlParameter companyFormParam = new SqlParameter("@companyForm", company.companyForm);
                command.Parameters.Add(companyFormParam);

                await command.ExecuteNonQueryAsync();

                await connection.CloseAsync();
            }
        }

        //Удаление данных о компании
        async public void DeleteCompany(int id)
        {
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                SqlCommand command = new SqlCommand("Delete from Сompanies where id = @id", connection);
                await connection.OpenAsync();

                SqlParameter idParam = new SqlParameter("@id", id);
                command.Parameters.Add(idParam);

                await command.ExecuteNonQueryAsync();
                await connection.CloseAsync();
            }
        }

        //Запрос на обновление данных о компании
        async public void UpdateCompany(Company company)
        {
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                SqlCommand command = new SqlCommand("Update Сompanies Set companyName = @companyName, companyForm = @companyForm where id = @id", connection);
                await connection.OpenAsync();

                SqlParameter idParam = new SqlParameter("@id", company.id);
                command.Parameters.Add(idParam);

                SqlParameter companyNameParam = new SqlParameter("@companyName", company.companyName);
                command.Parameters.Add(companyNameParam);

                SqlParameter companyFormParam = new SqlParameter("@companyForm", company.companyForm);
                command.Parameters.Add(companyFormParam);

                await command.ExecuteNonQueryAsync();

                await connection.CloseAsync();
            }
        }

        //Добавление работника
        async public void AddEmployee(Employee employee)
        {
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                SqlCommand command = new SqlCommand("Insert Into Employees(surname, name, patronymic, employmentDate, position," +
                    "companyId) Values(@surname, @name, @patronymic, @employmentDate, @position, @companyId)", connection);
                await connection.OpenAsync();

                SqlParameter surnameParam = new SqlParameter("@surname", employee.surname);
                command.Parameters.Add(surnameParam);

                SqlParameter nameParam = new SqlParameter("@name", employee.name);
                command.Parameters.Add(nameParam);

                SqlParameter patronymicParam = new SqlParameter("@patronymic", employee.patronymic);
                command.Parameters.Add(patronymicParam);

                SqlParameter employmentDateParam = new SqlParameter("@employmentDate", employee.employmentDate);
                command.Parameters.Add(employmentDateParam);

                SqlParameter positionParam = new SqlParameter("@position", employee.position);
                command.Parameters.Add(positionParam);

                SqlParameter companyParam = new SqlParameter("@companyId", employee.company.id);
                command.Parameters.Add(companyParam);

                await command.ExecuteNonQueryAsync();
                await connection.CloseAsync();
            }
        }

        //Получение списка всех работников
        async public Task<List<Employee>> GetAllEmployees()
        {
            List<Employee> employees = new List<Employee>();
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                SqlCommand command = new SqlCommand("Select Employees.id, surname, name, patronymic, employmentDate, position, " +
                    "companyId, companyName, companyForm From Employees join Сompanies on Сompanies.id = Employees.companyId", 
                    connection);

                await connection.OpenAsync();
                SqlDataReader dataReader = await command.ExecuteReaderAsync();
                while (await dataReader.ReadAsync())
                {
                    Employee employee = new Employee();
                    employee.id = Convert.ToInt32(dataReader["id"]);
                    employee.surname = dataReader["surname"].ToString();
                    employee.name = dataReader["name"].ToString();
                    employee.patronymic = dataReader["patronymic"].ToString();
                    employee.employmentDate = Convert.ToDateTime(dataReader["employmentDate"]);
                    employee.position = dataReader["position"].ToString();
                    Company company = new Company();
                    employee.company = company;
                    employee.company.id = Convert.ToInt32(dataReader["companyId"]);
                    employee.company.companyName = dataReader["companyName"].ToString();
                    employee.company.companyForm = dataReader["companyForm"].ToString();
                    employees.Add(employee);
                }
                await connection.CloseAsync();
            }
            return employees;
        }

        //Удаление радотника
        async public void DeleteEmployee(int id)
        {
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                SqlCommand command = new SqlCommand("Delete from Employees where id = @id", connection);
                await connection.OpenAsync();

                SqlParameter idParam = new SqlParameter("@id", id);
                command.Parameters.Add(idParam);

                await command.ExecuteNonQueryAsync();
                await connection.CloseAsync();
            }
        }

        //Запрос на редактирование данных работника
        async public void UpdateEmployee(Employee employee)
        {
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                SqlCommand command = new SqlCommand("Update Employees Set surname = @surname, name = @name, patronymic = @patronymic," +
                    " employmentDate = @employmentDate, position = @position, companyId = @companyId where id = @id", connection);
                await connection.OpenAsync();

                SqlParameter surnameParam = new SqlParameter("@surname", employee.surname);
                command.Parameters.Add(surnameParam);

                SqlParameter nameParam = new SqlParameter("@name", employee.name);
                command.Parameters.Add(nameParam);

                SqlParameter patronymicParam = new SqlParameter("@patronymic", employee.patronymic);
                command.Parameters.Add(patronymicParam);

                SqlParameter employmentDateParam = new SqlParameter("@employmentDate", employee.employmentDate);
                command.Parameters.Add(employmentDateParam);

                SqlParameter positionParam = new SqlParameter("@position", employee.position);
                command.Parameters.Add(positionParam);

                SqlParameter companyParam = new SqlParameter("@companyId", employee.company.id);
                command.Parameters.Add(companyParam);

                SqlParameter idParam = new SqlParameter("@id", employee.id);
                command.Parameters.Add(idParam);

                await command.ExecuteNonQueryAsync();
                await connection.CloseAsync();
            }
        }
    }
}
