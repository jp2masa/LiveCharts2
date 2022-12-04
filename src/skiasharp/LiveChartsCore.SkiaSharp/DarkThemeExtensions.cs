﻿// The MIT License(MIT)
//
// Copyright(c) 2021 Alberto Rodriguez Orozco & LiveCharts Contributors
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
// SOFTWARE.

using System;
using LiveChartsCore.Drawing;
using LiveChartsCore.Kernel;
using LiveChartsCore.Kernel.Sketches;
using LiveChartsCore.Measure;
using LiveChartsCore.SkiaSharpView.Drawing;
using LiveChartsCore.SkiaSharpView.Painting;
using LiveChartsCore.Themes;
using SkiaSharp;

namespace LiveChartsCore.SkiaSharpView;

/// <summary>
/// Defines the dark theme extensions.
/// </summary>
public static class DarkThemeExtensions
{
    /// <summary>
    /// Adds the light theme.
    /// </summary>
    /// <param name="settings">The settings.</param>
    /// <param name="additionalStyles">The additional styles.</param>
    /// <returns></returns>
    public static LiveChartsSettings AddDarkTheme(
        this LiveChartsSettings settings, Action<Theme<SkiaSharpDrawingContext>>? additionalStyles = null)
    {
        GaugeBuilder.DefaultLabelsPaint = new SolidColorPaint(new SKColor(250, 250, 250));

        return settings
            .HasTheme((Theme<SkiaSharpDrawingContext> theme) =>
            {
                _ = theme
                   .WithColors(ColorPalletes.MaterialDesign500)
                   .WithStyle(style =>
                       style
                           .HasRuleForCharts(chart =>
                           {
                               chart.AnimationsSpeed = TimeSpan.FromMilliseconds(800);
                               chart.EasingFunction = EasingFunctions.ExponentialOut;
                           })
                           .HasRuleForAxes(axis =>
                           {
                               axis.TextSize = 16;
                               axis.ShowSeparatorLines = true;
                               axis.NamePaint = new SolidColorPaint(new SKColor(235, 235, 235));
                               axis.LabelsPaint = new SolidColorPaint(new SKColor(200, 200, 200));
                               if (axis is ICartesianAxis cartesian)
                               {
                                   axis.SeparatorsPaint = cartesian.Orientation == AxisOrientation.X
                                        ? null
                                        : new SolidColorPaint(new SKColor(90, 90, 90));
                                   cartesian.Padding = new Padding(12);
                               }
                               else
                               {
                                   axis.SeparatorsPaint = new SolidColorPaint(new SKColor(90, 90, 90));
                               }
                           })
                           .HasRuleForLineSeries(lineSeries =>
                           {
                               var color = theme.GetSeriesColor(lineSeries);

                               lineSeries.GeometrySize = 14;
                               lineSeries.GeometryStroke = new SolidColorPaint(color, 4);
                               lineSeries.GeometryFill = new SolidColorPaint(new SKColor(30, 30, 30));
                               lineSeries.Stroke = new SolidColorPaint(color, 4);
                               lineSeries.Fill = new SolidColorPaint(color.WithAlpha(50));
                           })
                           .HasRuleForStepLineSeries(steplineSeries =>
                           {
                               var color = theme.GetSeriesColor(steplineSeries);

                               steplineSeries.GeometrySize = 14;
                               steplineSeries.GeometryStroke = new SolidColorPaint(color, 4);
                               steplineSeries.GeometryFill = new SolidColorPaint(new SKColor(30, 30, 30));
                               steplineSeries.Stroke = new SolidColorPaint(color, 4);
                               steplineSeries.Fill = new SolidColorPaint(color.WithAlpha(50));
                           })
                           .HasRuleForStackedLineSeries(stackedLine =>
                           {
                               var color = theme.GetSeriesColor(stackedLine);

                               stackedLine.GeometrySize = 0;
                               stackedLine.GeometryStroke = null;
                               stackedLine.GeometryFill = null;
                               stackedLine.Stroke = null;
                               stackedLine.Fill = new SolidColorPaint(color);
                           })
                           .HasRuleForBarSeries(barSeries =>
                           {
                               var color = theme.GetSeriesColor(barSeries);

                               barSeries.Stroke = null;
                               barSeries.Fill = new SolidColorPaint(color);
                               barSeries.Rx = 4;
                               barSeries.Ry = 4;
                           })
                           .HasRuleForStackedBarSeries(stackedBarSeries =>
                           {
                               var color = theme.GetSeriesColor(stackedBarSeries);

                               stackedBarSeries.Stroke = null;
                               stackedBarSeries.Fill = new SolidColorPaint(color);
                               stackedBarSeries.Rx = 0;
                               stackedBarSeries.Ry = 0;
                           })
                           .HasRuleForPieSeries(pieSeries =>
                           {
                               var color = theme.GetSeriesColor(pieSeries);

                               pieSeries.Stroke = null;
                               pieSeries.Fill = new SolidColorPaint(color);
                           })
                           .HasRuleForStackedStepLineSeries(stackedStep =>
                           {
                               var color = theme.GetSeriesColor(stackedStep);

                               stackedStep.GeometrySize = 0;
                               stackedStep.GeometryStroke = null;
                               stackedStep.GeometryFill = null;
                               stackedStep.Stroke = null;
                               stackedStep.Fill = new SolidColorPaint(color);
                           })
                           .HasRuleForHeatSeries(heatSeries =>
                           {
                               // ... rules here
                           })
                           .HasRuleForFinancialSeries(financialSeries =>
                           {
                               financialSeries.UpFill = new SolidColorPaint(new SKColor(139, 195, 74, 255));
                               financialSeries.UpStroke = new SolidColorPaint(new SKColor(139, 195, 74, 255), 3);
                               financialSeries.DownFill = new SolidColorPaint(new SKColor(239, 83, 80, 255));
                               financialSeries.DownStroke = new SolidColorPaint(new SKColor(239, 83, 80, 255), 3);
                           })
                           .HasRuleForPolarLineSeries(polarLine =>
                           {
                               var color = theme.GetSeriesColor(polarLine);

                               polarLine.GeometrySize = 14;
                               polarLine.GeometryStroke = new SolidColorPaint(color, 4);
                               polarLine.GeometryFill = new SolidColorPaint(new SKColor());
                               polarLine.Stroke = new SolidColorPaint(color, 4);
                               polarLine.Fill = new SolidColorPaint(color.WithAlpha(50));
                           }));

                additionalStyles?.Invoke(theme);
            });
    }
}
