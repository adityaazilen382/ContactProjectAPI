﻿namespace ContactAPI.Common.Models
{
    public enum ErrorCode
    {
        AUTHENTICATION_FAILED = 101,
        DATABASE_ERROR = 102,
        VALIDATION_ERROR = 103,
        USER_ALREADY_EXISTS = 104,
        INTERNAL_SERVICE_ERROR = 105,
        IO_OPERATION_FAILED = 106,
        USER_NOT_VERIFIED = 107,
        INVALID_INPUT = 108,
        RESTAURANT_OFFLINE = 112,
        USER_NOT_FOUND = 114,
        APPLICATION_VERSION_MISMATCH = 115,
        UNKNOWN_ERROR = 116,
        DUPLICATE_REST = 117,
        DUPLICATE_EMAIL = 118,
        INVALID_PASS = 119,
        DUPLICATE_DEVICE_USERNAME = 120,
        SUCCESS = 200,
        TABLE_ALREADY_USED = 201,
        SAME_RESTAURANT_VERSION = 202,
        RESTAURANT_NOT_FOUND = 121,
        SERVER_NOT_FOUND = 122,
        PAGER_NOT_FOUND = 123,
        SERVER_NOT_MAPPED = 124,
        ALREADY_MAPPED_WITH_PAGER = 125,
        DUPLICATE_PAGER_NUMBER = 126,
        EMAIL_FAILED = 127,
        CONFIGURATION_NOT_FOUND = 128
    }

}
