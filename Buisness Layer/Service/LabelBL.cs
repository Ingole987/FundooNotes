using Buisness_Layer.Interface;
using Common_Layer.Models;
using Repository_Layer.Entity;
using Repository_Layer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Buisness_Layer.Service
{
    public class LabelBL : ILabelBL
    {
        private readonly ILabelRL labelRL;
        public LabelBL(ILabelRL labelRL)
        {
            this.labelRL = labelRL;
        }
        public LabelEntity AddLabel(NotesLabel noteslabel, long userId)
        {
            try
            {
                return labelRL.AddLabel(noteslabel , userId);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public LabelEntity Update(string label, long userId, long noteId)
        {
            try
            {
                return labelRL.Update(label, userId, noteId);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public bool Delete(long labelId)
        {
            try
            {
                return labelRL.Delete(labelId);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<LabelEntity> GetLabel(long noteId)
        {
            try
            {
                return labelRL.GetLabel(noteId);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<LabelEntity> GetLabelTableData()
        {
            try
            {
                return labelRL.GetLabelTableData();
            }
            catch (Exception)
            {

                throw;
            }
        }

    }


}
