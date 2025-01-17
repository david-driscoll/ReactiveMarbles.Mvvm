// Copyright (c) 2019-2022 ReactiveUI Association Incorporated. All rights reserved.
// ReactiveUI Association Incorporated licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Runtime.Serialization;

using DynamicData.Binding;

using ReactiveMarbles.PropertyChanged;

namespace ReactiveMarbles.Mvvm.Benchmarks.Memory;

/// <summary>
/// A dummy rx object.
/// </summary>
public class DummyRxObject : RxObject
{
    private readonly IValueBinder<string?> _observableProperty;

    [IgnoreDataMember]
    private string? _isNotNullString;

    [IgnoreDataMember]
    private string? _isOnlyOneWord;

    private string? _notSerialized;

    [IgnoreDataMember]
    private int? _nullableInt;

    [IgnoreDataMember]
    private string? _pocoProperty;

    [IgnoreDataMember]
    private List<string>? _stackOverflowTrigger;

    [IgnoreDataMember]
    private string? _usesExprRaiseSet;

    /// <summary>
    /// Initializes a new instance of the <see cref="DummyRxObject"/> class.
    /// </summary>
    public DummyRxObject()
    {
        TestCollection = new ObservableCollectionExtended<int>();

        _observableProperty =
            this.WhenChanged(x => x.IsOnlyOneWord)
                .Select(x => x + "Changed")
                .AsValue(onChanged: x => RaisePropertyChanged(nameof(ObservableProperty)));
    }

    /// <summary>
    /// Gets or sets the is not null string.
    /// </summary>
    [DataMember]
    public string? IsNotNullString
    {
        get => _isNotNullString;
        set => RaiseAndSetIfChanged(ref _isNotNullString, value);
    }

    /// <summary>
    /// Gets or sets the is only one word.
    /// </summary>
    [DataMember]
    public string? IsOnlyOneWord
    {
        get => _isOnlyOneWord;
        set => RaiseAndSetIfChanged(ref _isOnlyOneWord, value);
    }

    /// <summary>
    /// Gets or sets the not serialized.
    /// </summary>
    public string? NotSerialized
    {
        get => _notSerialized;
        set => RaiseAndSetIfChanged(ref _notSerialized, value);
    }

    /// <summary>
    /// Gets or sets the nullable int.
    /// </summary>
    [DataMember]
    public int? NullableInt
    {
        get => _nullableInt;
        set => RaiseAndSetIfChanged(ref _nullableInt, value);
    }

    /// <summary>
    /// Gets or sets the poco property.
    /// </summary>
    [DataMember]
    public string? PocoProperty
    {
        get => _pocoProperty;
        set => _pocoProperty = value;
    }

    /// <summary>
    /// Gets or sets the stack overflow trigger.
    /// </summary>
    [DataMember]
    public List<string>? StackOverflowTrigger
    {
        get => _stackOverflowTrigger;
        set => RaiseAndSetIfChanged(ref _stackOverflowTrigger, value?.ToList());
    }

    /// <summary>
    /// Gets or sets the test collection.
    /// </summary>
    [DataMember]
    public ObservableCollectionExtended<int> TestCollection { get; protected set; }

    /// <summary>
    /// Gets or sets the uses expr raise set.
    /// </summary>
    [DataMember]
    public string? UsesExprRaiseSet
    {
        get => _usesExprRaiseSet;
        set => RaiseAndSetIfChanged(ref _usesExprRaiseSet, value);
    }

    /// <summary>
    /// Gets the observable property.
    /// </summary>
    public string? ObservableProperty => _observableProperty.Value;
}