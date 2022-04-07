using Common_Layer.Models;
using Repository_Layer.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Buisness_Layer.Interface
{
    public interface ILabelBL
    {
        public LabelEntity AddLabel(NotesLabel noteslabel, long userId);
        public LabelEntity Update(string label, long userId, long noteId);
        public bool Delete(long labelId);
        public IEnumerable<LabelEntity> GetLabel(long noteId);
        public IEnumerable<LabelEntity> GetLabelTableData();

    }
}
