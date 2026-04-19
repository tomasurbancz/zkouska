using Cviceni.Database;
using Cviceni.Database.Entity;
using Cviceni.Database.Repository;
using Cviceni.WFA.Form;
using Timer = System.Windows.Forms.Timer;

namespace Cviceni.WFA.Controls;

public partial class ClassListControl : UserControl
{
    private bool _refreshing;
    private Timer _refreshTimer;
    private int _remaining = 5;
    private ClassRepository _classRepository;
    private DatabaseContext _databaseContext;
    private Dictionary<ListViewItem, Guid> _binded;
    private int _currentPage = 1;
    private int _items = 0;
    
    public ClassListControl(DatabaseContext databaseContext)
    {
        InitializeComponent();
        _classRepository = new ClassRepository(databaseContext);
        _binded = new  Dictionary<ListViewItem, Guid>();
        _databaseContext = databaseContext;
        _refreshTimer = new Timer();
        _refreshTimer.Interval = 1000;
        nextRefresh.Visible = false;
        _refreshTimer.Tick += (e, q) =>
        {
            if (!_refreshing) return;
            _remaining--;
            nextRefresh.Text = $"Next refresh in {_remaining}sec";
            if (_remaining <= 0)
            {
                nextRefresh.Text = "Refreshing...";
                LoadTable();
                _remaining = 5;
            }
        };
        _refreshTimer.Start();
        label1.Visible = false;
        label2.Visible = false;
    }

    private void StudentListControl_Load(object sender, EventArgs e)
    {
        LoadTable();
    }

    private async void LoadTable()
    {
        listView1.Items.Clear();
        _binded.Clear();
        List<ClassEntity> entities = await _classRepository.GetAll();
        _items = 0;
        int start = 1 + ((_currentPage - 1) * 10);
        int end = 10 + ((_currentPage - 1) * 10); 
        entities.ForEach(entity =>
        {
            _items++;
            if (_items >= start && _items <= end)
            {
                ListViewItem item = new ListViewItem(entity.Year + " " + entity.Code);
                listView1.Items.Add(item);
                _binded.Add(item, entity.Id);
            }
        });
        if (_items < start && _currentPage != 1)
        {
            _currentPage--;
            LoadTable();
            label1.Visible = true;
            if (_currentPage == 1)
            {
                label1.Visible = false;
            }
        }

        if (_items > end)
        {
            label2.Visible = true;
        }
        int maxPage = (int) Math.Floor(_items / 10f) + (_items % 10 == 0 ? 0 : 1);
        label3.Text = $"{_currentPage}/{Math.Max(1, maxPage)}";
    }
    
    private void autoRefresh_CheckedChanged(object sender, EventArgs e)
    {
        _refreshing = autoRefresh.Checked;
        nextRefresh.Visible = _refreshing;
        _remaining = 5;
        nextRefresh.Text = $"Next refresh in {_remaining}sec";
    }
    
    private void refresh_Click(object sender, EventArgs e)
    {
        LoadTable();
    }
    
    private void add_Click_1(object sender, EventArgs e)
    {
        ClassForm classForm = new ClassForm(_databaseContext, Guid.Empty);
        classForm.Show();
    }

    private void listView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (listView1.SelectedItems.Count > 0)
        {
            Guid id = _binded[listView1.SelectedItems[0]];
            ClassForm classForm = new ClassForm(_databaseContext, id);
            classForm.Show();
        }
    }

    private void label2_Click(object sender, EventArgs e)
    {
        label1.Visible = true;
        _currentPage++;
        int maxPage = (int) Math.Floor(_items / 10f) + (_items % 10 == 0 ? 0 : 1);
        if (_currentPage == maxPage)
        {
            label2.Visible = false;
        }
        LoadTable();
    }

    private void label1_Click(object sender, EventArgs e)
    {
        _currentPage--;
        if (_currentPage == 1)
        {
            label1.Visible = false;
        }
        LoadTable();
    }
}