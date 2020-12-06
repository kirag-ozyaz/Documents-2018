using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Documents.Forms.TechnologicalConnection.Contract
{
	public static class Bar
	{
		public static void PintaDegradado(Color oColor, DataGridViewCellPaintingEventArgs e)
		{
			Bar.PintaDegradado(oColor, e, -1);
		}

		public static void PintaDegradado(Color oColor, DataGridViewCellPaintingEventArgs e, int iPorcentaje)
		{
			Color[] color_ = new Color[]
			{
				oColor
			};
			int[] int_ = new int[]
			{
				iPorcentaje
			};
			if (iPorcentaje == -1)
			{
				int[] int_2 = new int[0];
				Bar.smethod_0(color_, e, int_2);
				return;
			}
			Bar.smethod_0(color_, e, int_);
		}

		public static void PintaDegradado(Color oColor, DataGridViewCellPaintingEventArgs e, int iPorcentaje, int iObjetivo, Color oColorObjetivo)
		{
			Color[] color_ = new Color[]
			{
				oColor,
				oColorObjetivo
			};
			int[] int_ = new int[]
			{
				iPorcentaje,
				iObjetivo
			};
			Bar.smethod_0(color_, e, int_);
		}

		private static void smethod_0(Color[] color_0, DataGridViewCellPaintingEventArgs dataGridViewCellPaintingEventArgs_0, int[] int_0)
		{
			LinearGradientBrush linearGradientBrush = null;
			LinearGradientBrush linearGradientBrush2 = null;
			LinearGradientBrush linearGradientBrush3 = null;
			Color color = color_0[0];
			try
			{
				Rectangle clipBounds = new Rectangle(dataGridViewCellPaintingEventArgs_0.CellBounds.X - 1, dataGridViewCellPaintingEventArgs_0.CellBounds.Y - 1, dataGridViewCellPaintingEventArgs_0.CellBounds.Width, dataGridViewCellPaintingEventArgs_0.CellBounds.Height);
				for (int i = 0; i < int_0.Length; i++)
				{
					if (int_0[i] > 100)
					{
						int_0[i] = 100;
					}
				}
				Rectangle rect = default(Rectangle);
				Rectangle rect2 = default(Rectangle);
				Rectangle rect3 = default(Rectangle);
				Rectangle rect4 = default(Rectangle);
				Rectangle rect5 = default(Rectangle);
				bool flag = false;
				if (int_0.Length != 0)
				{
					flag = true;
					int num = int_0[0];
					if (num > 0)
					{
						rect = new Rectangle(clipBounds.X + 4, clipBounds.Y + 4, Convert.ToInt32(Math.Round((double)((clipBounds.Width - 7) * num) * 0.01 + 0.49)), (int)Math.Round((double)(clipBounds.Height - 8) / 2.0));
						if (rect.Width > clipBounds.Width - 7)
						{
							rect.Width = clipBounds.Width - 7;
						}
						rect2 = new Rectangle(clipBounds.X + 4, rect.Bottom - 1, rect.Width, clipBounds.Height - 6 - rect.Height);
						rect4 = new Rectangle(clipBounds.X + 4, clipBounds.Y + 4, clipBounds.Width - 7, clipBounds.Height - 7);
						linearGradientBrush = new LinearGradientBrush(rect, Color.White, Color.FromArgb(180, color), LinearGradientMode.Vertical);
						linearGradientBrush2 = new LinearGradientBrush(rect2, color, Color.FromArgb(70, color), LinearGradientMode.Vertical);
					}
					if (int_0.Length > 1)
					{
						int num2 = int_0[1];
						int num3 = clipBounds.X + 4 + Convert.ToInt32(Math.Round((double)((clipBounds.Width - 7) * num2) * 0.01 + 0.49));
						int num4 = num3 - 20;
						if (num4 < clipBounds.X + 4)
						{
							num4 = clipBounds.X + 4;
						}
						rect3 = new Rectangle(num4, clipBounds.Y + 2, num3 - num4, clipBounds.Height - 4);
						linearGradientBrush3 = new LinearGradientBrush(rect3, Color.FromArgb(0, color_0[1]), color_0[1], LinearGradientMode.Horizontal);
					}
					rect5 = new Rectangle(clipBounds.X + 3, clipBounds.Y + 3, clipBounds.Width - 6, clipBounds.Height - 6);
				}
				else
				{
					rect = new Rectangle(clipBounds.X + 1, clipBounds.Y + 1, clipBounds.Width - 1, Convert.ToInt32(Math.Round((double)clipBounds.Height / 2.0)));
					rect2 = new Rectangle(clipBounds.X + 1, rect.Bottom - 1, clipBounds.Width - 1, clipBounds.Height - rect.Height);
					rect4 = new Rectangle(clipBounds.X + 1, clipBounds.Y + 1, clipBounds.Width - 1, clipBounds.Height);
					linearGradientBrush = new LinearGradientBrush(rect, Color.White, Color.FromArgb(180, color), LinearGradientMode.Vertical);
					linearGradientBrush2 = new LinearGradientBrush(rect2, color, Color.FromArgb(70, color), LinearGradientMode.Vertical);
				}
				dataGridViewCellPaintingEventArgs_0.PaintBackground(dataGridViewCellPaintingEventArgs_0.CellBounds, true);
				if (flag)
				{
					dataGridViewCellPaintingEventArgs_0.Graphics.DrawRectangle(Pens.DimGray, rect5);
				}
				if (linearGradientBrush != null)
				{
					dataGridViewCellPaintingEventArgs_0.Graphics.FillRectangle(Brushes.White, rect4);
					dataGridViewCellPaintingEventArgs_0.Graphics.FillRectangle(linearGradientBrush, rect);
					dataGridViewCellPaintingEventArgs_0.Graphics.FillRectangle(linearGradientBrush2, rect2);
				}
				if (linearGradientBrush3 != null)
				{
					dataGridViewCellPaintingEventArgs_0.Graphics.FillRectangle(linearGradientBrush3, rect3);
				}
				dataGridViewCellPaintingEventArgs_0.PaintContent(clipBounds);
				dataGridViewCellPaintingEventArgs_0.Paint(clipBounds, DataGridViewPaintParts.Border);
				dataGridViewCellPaintingEventArgs_0.Handled = true;
			}
			catch (Exception)
			{
			}
			finally
			{
				if (linearGradientBrush != null)
				{
					linearGradientBrush.Dispose();
					linearGradientBrush = null;
				}
				if (linearGradientBrush2 != null)
				{
					linearGradientBrush2.Dispose();
					linearGradientBrush2 = null;
				}
				if (linearGradientBrush3 != null)
				{
					linearGradientBrush3.Dispose();
					linearGradientBrush3 = null;
				}
			}
		}
	}
}
