using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#if WINDOWS
using Windows.Storage.Streams;
#endif

namespace CommunityToolkit.Maui.Views;

/// <summary>
/// 
/// </summary>
public sealed class StreamMediaSource : MediaSource
{
	/// <summary>
	/// 
	/// </summary>
	public static readonly BindableProperty ContentTypeProperty
		= BindableProperty.Create(nameof(ContentType), typeof(string), typeof(StreamMediaSource), propertyChanged: OnContentTypeChanged);



#if WINDOWS
	/// <summary>
	/// 
	/// </summary>
	public static readonly BindableProperty StreamProperty
		= BindableProperty.Create(nameof(Stream), typeof(IRandomAccessStream), typeof(StreamMediaSource), propertyChanged: OnStreamSourceChanged);

	/// <summary>
	/// 
	/// </summary>
	public IRandomAccessStream? Stream
	{
		get => (IRandomAccessStream?)GetValue(StreamProperty);
		set => SetValue(StreamProperty, value);
	}
#endif
	/// <summary>
	/// 
	/// </summary>
	public string? ContentType
	{
		get => (string?)GetValue(ContentTypeProperty);
		set => SetValue(ContentTypeProperty, value);
	}




	static void OnStreamSourceChanged(BindableObject bindable, object oldValue, object newValue) =>
		((StreamMediaSource)bindable).OnSourceChanged();

	static void OnContentTypeChanged(BindableObject bindable, object oldValue, object newValue) =>
		((StreamMediaSource)bindable).OnSourceChanged();
}
