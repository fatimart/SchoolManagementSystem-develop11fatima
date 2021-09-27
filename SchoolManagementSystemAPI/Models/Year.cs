//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SchoolManagementSystemAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;

    public partial class Year
    {
        public int YearID { get; set; }
        public string YearNum { get; set; }

        public SchoolMSEntities ty = new SchoolMSEntities();

        private ObservableCollection<Year> _yearRecord;
        public ObservableCollection<Year> AllYears
        {
            get
            {
                return _yearRecord;
            }
            set
            {
                _yearRecord = value;
            }
        }

        public List<Year> GetAll1 ()
        {
            return ty.Years.ToList();


        }
        public Year GetYear ( int YearID )
        {
                return ty.Years
                         .Where(s => s.YearID == YearID)
                         .FirstOrDefault() as Year;
           
        }


        public void GetAll ()
        {
            AllYears = new ObservableCollection<Year>();
            GetAll1().ForEach(data => AllYears.Add(new Year()
            {
                YearID = data.YearID,
                YearNum = data.YearNum

            }));

        }

        //MARK: DataAccess Functions
        public void AddYear ( Year year )
        {
            ty.Years.Add(year);
            ty.SaveChanges();

        }

        public void UpdateYear ( int YearId, Year updateYears )
        {

            var Year = ty.Years.Where(y => y.YearID == YearId).FirstOrDefault();
            if (Year != null)
            {
                if (!string.IsNullOrWhiteSpace(updateYears.YearNum))
                    Year.YearNum = updateYears.YearNum;

                ty.SaveChanges();


            }
        }

        public void DeleteYear ( int yearID )
        {
            if (yearID >0)
            {
                var deleteYears = ty.Years.Where(m => m.YearID == yearID).Single();
                ty.Years.Remove(deleteYears);
                ty.SaveChanges();
            }


        }

        public bool CheckYearID ( int YearID )
        {

            if (ty.Years.Any(o => o.YearID == YearID))
            {
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}
