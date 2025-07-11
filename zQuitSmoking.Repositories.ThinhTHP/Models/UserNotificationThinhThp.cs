﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace zQuitSmoking.Repositories.ThinhTHP.Models;

public partial class UserNotificationThinhThp
{
    public int UserNotificationThinhThpid { get; set; }

    [Required(ErrorMessage = "User Account ID is required.")]
    public int UserAccountId { get; set; }

    [Required(ErrorMessage = "Notification ID is required.")]
    public int NotificationThinhThpid { get; set; }

    public DateTime? SentDate { get; set; }

    public bool IsRead { get; set; }

    [StringLength(500, ErrorMessage = "Response cannot exceed 500 characters.")]
    public string Response { get; set; }

    [Required(ErrorMessage = "Status is required.")]
    [StringLength(50, ErrorMessage = "Status cannot exceed 50 characters.")]
    public string Status { get; set; }

    [Range(0, 10, ErrorMessage = "Attempt count must be between 0 and 10.")]
    public int? AttemptCount { get; set; }

    public DateTime? LastAttemptDate { get; set; }

    public virtual NotificationThinhThp NotificationThinhThp { get; set; }

    public virtual SystemUserAccount UserAccount { get; set; }
}