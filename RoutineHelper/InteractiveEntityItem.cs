using System;
using System.ComponentModel;

namespace RoutineHelper;

public class InteractiveEntityItem : INotifyPropertyChanged
{
	private bool _isCandidateSource;

	private bool _isCandidateTarget;

	private bool _isSelectedAsSource;

	private bool _isSelectedAsTarget;

	private bool _isSelectable = true;

	public int EntityId { get; set; }

	public InteractiveEntityKind Kind { get; set; }

	public string Status { get; set; }

	public string OnlineCardImage { get; set; }

	public bool IsCandidateSource
	{
		get
		{
			return _isCandidateSource;
		}
		set
		{
			if (value != _isCandidateSource)
			{
				_isCandidateSource = value;
				OnPropertyChanged("IsCandidateSource");
			}
		}
	}

	public bool IsCandidateTarget
	{
		get
		{
			return _isCandidateTarget;
		}
		set
		{
			if (value != _isCandidateTarget)
			{
				_isCandidateTarget = value;
				OnPropertyChanged("IsCandidateTarget");
			}
		}
	}

	public bool IsSelectedAsSource
	{
		get
		{
			return _isSelectedAsSource;
		}
		set
		{
			if (value != _isSelectedAsSource)
			{
				_isSelectedAsSource = value;
				OnPropertyChanged("IsSelectedAsSource");
			}
		}
	}

	public bool IsSelectedAsTarget
	{
		get
		{
			return _isSelectedAsTarget;
		}
		set
		{
			if (value != _isSelectedAsTarget)
			{
				_isSelectedAsTarget = value;
				OnPropertyChanged("IsSelectedAsTarget");
			}
		}
	}

	public bool IsSelectable
	{
		get
		{
			return _isSelectable;
		}
		set
		{
			if (value != _isSelectable)
			{
				_isSelectable = value;
				OnPropertyChanged("IsSelectable");
			}
		}
	}

	public string PrimaryText
	{
		get
		{
			if (string.IsNullOrWhiteSpace(Status))
			{
				return string.Empty;
			}
			string[] array = Status.Split(new string[2] { "\r\n", "\n" }, StringSplitOptions.RemoveEmptyEntries);
			return (array.Length != 0) ? array[0] : Status;
		}
	}

	public event PropertyChangedEventHandler PropertyChanged;

	public override string ToString()
	{
		return Status ?? string.Empty;
	}

	private void OnPropertyChanged(string name)
	{
		this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
	}
}
