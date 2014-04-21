/*
Navicat MySQL Data Transfer

Source Server         : War-Emu
Source Server Version : 50617
Source Host           : localhost:3306
Source Database       : war-world

Target Server Type    : MYSQL
Target Server Version : 50617
File Encoding         : 65001

Date: 2014-04-20 21:55:47
*/

SET FOREIGN_KEY_CHECKS=0;

-- ----------------------------
-- Table structure for quests
-- ----------------------------
DROP TABLE IF EXISTS `quests`;
CREATE TABLE `quests` (
  `Entry` smallint(5) unsigned NOT NULL,
  `Name` varchar(250) NOT NULL,
  `Type` tinyint(3) unsigned NOT NULL,
  `Level` tinyint(3) unsigned NOT NULL,
  `Description` text NOT NULL,
  `Particular` text NOT NULL,
  `XP` int(10) unsigned NOT NULL,
  `Gold` int(10) unsigned NOT NULL,
  `Given` text NOT NULL,
  `Choice` text NOT NULL,
  `ChoiceCount` tinyint(3) unsigned NOT NULL DEFAULT '1',
  `PrevQuest` smallint(5) unsigned NOT NULL,
  `Quests_ID` text,
  `ProgressText` text NOT NULL,
  `OnCompletionQuest` text NOT NULL,
  PRIMARY KEY (`Entry`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of quests
-- ----------------------------