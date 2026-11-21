using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NguyenVanTruong_241230874.Models;

public partial class TaiSan
{
    [Key]
    public int MaTs { get; set; }

    public int MaLoai { get; set; }
    [Required(ErrorMessage = "Tên tài sản không được để trống")]
    public string TenTs { get; set; } = null!;
    [Required(ErrorMessage ="Nguyên giá không được để trống")]
    [Range(1,2000, ErrorMessage ="Nguyên giá phải trong khoảng từ 1 đến 2000 triệu")]
    public decimal? NguyenGia { get; set; }
    [Required(ErrorMessage ="Ảnh không được để trống")]
    [RegularExpression(@".+\.(jpg|jpeg|png|webp)$",ErrorMessage ="Ảnh phải có định dạng jpg,jpeg,png,webp")]
    public string? Anh { get; set; }

    public virtual LoaiTaiSan MaLoaiNavigation { get; set; } = null!;
}
